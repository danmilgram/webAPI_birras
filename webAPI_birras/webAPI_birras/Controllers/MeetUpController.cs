﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using webAPI_birras.Models;
using webAPI_birras.Services;
using webAPI_birras.Helpers;
using webAPI_birras.Models.requestModels;
using Newtonsoft.Json.Linq;
using webAPI_birras.Controllers.Validators;
using Microsoft.AspNetCore.Authorization;
using webAPI_birras.Controllers.Functions;
using Microsoft.AspNetCore.Cors;

namespace webAPI_birras.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeetUpController : ControllerBase
    {
        private readonly MeetUpService _MeetUpService;
        private readonly UserService _UserService;

        public MeetUpController(MeetUpService MeetUpService, UserService UserService)
        {
            _MeetUpService = MeetUpService;
            _UserService = UserService;
        }

        [HttpGet]
        public ActionResult<List<MeetUp>> Get() =>
        _MeetUpService.Get();

        [HttpGet("{id:length(24)}", Name = "GetMeetUp")]
        public ActionResult<MeetUp> Get(string id)
        {
            var MeetUp = _MeetUpService.Get(id);

            if (MeetUp == null)
            {
                return NotFound();
            }

            return Ok(MeetUp);
        }

        [HttpGet("GetMeetUpWeather/{id:length(24)}")]
        public ActionResult GetMeetUpWeather(string id)
        {
            MeetUp meet = _MeetUpService.Get(id);

            if (meet == null)
            {
                return NotFound();
            }
            else
            {
                MeetUpValidator meetUpValidator = new MeetUpValidator();
                string msg = WeatherValidator.CanForecast(meet.date);

                if (msg == WeatherValidatorMessage.weatherOk)
                {
                    int daydiff = ((TimeSpan)(meet.date - DateTime.Now)).Days;
                    JToken forecast = WeatherService.getDailyForecast(daydiff);

                    return Ok(forecast.ToString());
                }
                else
                {
                    return ValidationProblem(msg, null, 442);
                }
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("CalculateBeers/{id:length(24)}")]
        public ActionResult CalculateBeers(string id)
        {
            MeetUp meet = _MeetUpService.Get(id);

            if (meet == null)
            {
                return NotFound();
            }
            else
            {
                MeetUpFunctions meetUpFunctions = new MeetUpFunctions();

                if (MeetUpValidatorMessage.OkGuests == MeetUpValidator.ValidateGuest(meet))
                {
                    if (WeatherValidatorMessage.weatherOk == WeatherValidator.CanForecast(meet.date))
                    {
                        int daydiff = Convert.ToInt32((meet.date - DateTime.Now.Date).TotalDays);
                        JToken forecast = WeatherService.getDailyForecast(daydiff);

                        string temp = forecast.SelectToken("day").ToString();

                        int beers = meetUpFunctions.CalculateBeers(meet.guests.Count, Convert.ToDouble(temp));

                        return Ok(beers);
                    }
                    else
                    {
                        return ValidationProblem(WeatherValidatorMessage.emptyForecast, null, 442);
                    }
                }
                else
                {
                    return ValidationProblem(MeetUpValidatorMessage.noGuests, null, 442);
                }
            }
        }


        [Authorize(Roles = "Admin")]
        [HttpPut("/api/MeetUp/Invite/{id:length(24)}")]
        public ActionResult Invite(string id, [FromBody] reqListMails req)
        {
            MeetUp meet = _MeetUpService.Get(id);

            if (meet == null)
            {
                return NotFound();
            }
            {
                MeetUpValidator meetUpValidator = new MeetUpValidator();
                bool fin = MeetUpValidator.ValidateFin(meet);

                if (fin == false)
                    foreach (var mail in req.mails)
                    {
                        Guest invite = new Guest()
                        {
                            mail = mail,
                            accepted = false,
                            checkedIn = false
                        };

                        if (! meet.guests.Exists(meet => meet.mail == mail)){                            
                            meet.guests.Add(invite);
                        }
                        EmailService.SendMail(mail, Invitation.Subject, Invitation.getText(meet));
                    }
                else
                {
                    return ValidationProblem(MeetUpValidatorMessage.isFinalized, null, 442);
                }

                _MeetUpService.Update(id, meet);
            }
            return Ok(meet);
        }


        [Authorize]
        [HttpPut("/api/MeetUp/Join/{id:length(24)}")]
        public ActionResult Join(string id, [FromBody] reqMail req)
        {
            bool accepted = false ;
            User user = _UserService.GetByMail(req.mail);
            MeetUp meet = _MeetUpService.Get(id);

            if (user == null | meet == null)
            {
                return NotFound();
            }
            else
            { 
                bool fin = MeetUpValidator.ValidateFin(meet);

                if (fin == false)
                {
                    foreach (var inv in meet.guests)
                    {
                        if (inv.mail == req.mail)
                        {
                            inv.accepted = true;
                            _MeetUpService.Update(id, meet);
                            accepted = true;
                        }
                    }

                    return accepted ? Ok(meet) : ValidationProblem(MeetUpValidatorMessage.notInvited);
                }                    
                else
                {
                    return ValidationProblem(MeetUpValidatorMessage.isFinalized,null,442);
                }
            }
        }

        [Authorize]
        [HttpPut("/api/MeetUp/CheckIn/{id:length(24)}")]
        public ActionResult CheckIn(string id, [FromBody] reqMail req)
        {
            bool accepted = false;
            User user = _UserService.GetByMail(req.mail);
            MeetUp meet = _MeetUpService.Get(id);

            if (user == null || meet == null)
            {
                return NotFound();
            }
            else
            {
                bool fin = MeetUpValidator.ValidateFin(meet);

                if (fin == true)
                {
                    foreach (var inv in meet.guests)
                    {
                        if (inv.mail == req.mail)
                        {
                            inv.checkedIn = true;
                            inv.accepted = true;
                            _MeetUpService.Update(id, meet);
                            accepted = true;
                        }
                    }

                    return accepted ? Ok(meet) : ValidationProblem(MeetUpValidatorMessage.notInvited);

                }
                else
                {
                    return ValidationProblem(MeetUpValidatorMessage.isNotFinalized, null, 442);
                }
            }

        }



        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult<MeetUp> Create(reqNewMeet req)
        {
            MeetUp meet = new MeetUp();

            meet.Id = TypeHelpers.GetRandomHexNumber(24);
            meet.name = req.name;
            meet.description = req.description;
            meet.date = req.date;
            meet.guests = new List<Guest>();

            bool fin = MeetUpValidator.ValidateFin(meet);

            if (fin == false) 
            {
             
                _MeetUpService.Create( meet);

                return Ok(meet);
            }
            else
            {
                return ValidationProblem(MeetUpValidatorMessage.isFinalized, null, 442);
            }
        }
        [Authorize(Roles = "Admin")]
        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, MeetUp MeetUpIn)
        {
            var MeetUp = _MeetUpService.Get(id);

            if (MeetUp == null)
            {
                return NotFound();
            }

            _MeetUpService.Update(id, MeetUpIn);

            return Ok(MeetUp);
        }

    }
}
