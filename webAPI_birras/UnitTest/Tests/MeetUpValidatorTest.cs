using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using webAPI_birras.Controllers.Validators;
using webAPI_birras.Models;
using webAPI_birras.Models.requestModels;

namespace webAPI_birras_UnitTest.Tests
{
    [TestClass]
    public class MeetUpValidatorTest
    {
        [TestMethod]
        public void ValidateFin_test()
        {
            MeetUp meet = new MeetUp();

            meet.date = DateTime.Now.AddDays(2);
            bool fin = MeetUpValidator.ValidateFin(meet);
            Assert.IsFalse(fin);

            meet.date = DateTime.Now.AddDays(-2);
            fin = MeetUpValidator.ValidateFin(meet);
            Assert.IsTrue(fin);
        }

        [TestMethod]
        public void MeetUpWeatherValidation_testNoGuests()
        {
            MeetUp meetUp = new MeetUp();
            List<Guest> guestList = new List<Guest>();

            meetUp.guests = guestList;

            string msg = MeetUpValidator.MeetUpWeatherValidation(meetUp);

            Assert.IsTrue(msg == MeetUpValidatorMessage.noGuests);
        }

        [TestMethod]
        public void MeetUpWeatherValidation_testIsFinalized()
        {
            MeetUp meetUp = new MeetUp();
            List<Guest> guestList = new List<Guest>();
            guestList.Add(new Guest { mail = "prueba@pruebita.com.ar", accepted = false, checkedIn = false });

            meetUp.guests = guestList;
            meetUp.date = DateTime.Now.AddDays(-3);

            string msg = MeetUpValidator.MeetUpWeatherValidation(meetUp);

            Assert.IsTrue(msg == MeetUpValidatorMessage.isFinalized);
        }

        [TestMethod]
        public void MeetUpWeatherValidation_testEmptyForecast()
        {
            MeetUp meetUp = new MeetUp();
            List<Guest> guestList = new List<Guest>();
            guestList.Add(new Guest { mail = "prueba@pruebita.com.ar", accepted = false, checkedIn = false });

            meetUp.guests = guestList;
            meetUp.date = DateTime.Now.AddDays(8);

            string msg = MeetUpValidator.MeetUpWeatherValidation(meetUp);

            Assert.IsTrue(msg == MeetUpValidatorMessage.emptyForecast);
        }

        [TestMethod]
        public void MeetUpWeatherValidation_weatherOk()
        {
            MeetUp meetUp = new MeetUp();
            List<Guest> guestList = new List<Guest>();
            guestList.Add(new Guest { mail = "prueba@pruebita.com.ar", accepted = false, checkedIn = false });

            meetUp.guests = guestList;
            meetUp.date = DateTime.Now.AddDays(3);

            string msg = MeetUpValidator.MeetUpWeatherValidation(meetUp);

            Assert.IsTrue(msg == MeetUpValidatorMessage.weatherOk);
        }

    }
}
