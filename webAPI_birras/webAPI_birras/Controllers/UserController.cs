using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using webAPI_birras.Models;
using webAPI_birras.Services;
using webAPI_birras.Helpers;
using Microsoft.AspNetCore.Authorization;
using webAPI_birras.Controllers.Validators;
using webAPI_birras.Models.requestModels;

namespace webAPI_birras.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _UserService;
        private readonly AuthService _authService;

        public UserController(UserService UserService, AuthService AuthService)
        {
            _UserService = UserService;
            _authService = AuthService;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult<List<User>> Get() =>
            _UserService.Get();

        [Authorize]
        [HttpGet("{id:length(24)}", Name = "GetUser")]
        public ActionResult<User> Get(string id)
        {
            var User = _UserService.Get(id);

            if (User == null)
            {
                return NotFound();
            }

            return User;
        }

        [HttpPost("SignIn")]
        public ActionResult<User> Create([FromBody] reqUser req)
        {
            var mail = _UserService.GetByMail(req.mail);

            if (mail == null)
            {
                User user = new User
                {
                    Id = TypeHelpers.GetRandomHexNumber(24),
                    password = _authService.SecurePassword(req.password),
                    name = req.name,
                    surName = req.surName,
                    mail = req.mail,
                    phone = req.phone,
                    notifications = new List<UserNotification>(),
                    role = Role.User
                };
                
                _UserService.Create(user);

                return CreatedAtRoute("GetUser", new { id = user.Id.ToString() }, User);
            }
            else
            {
                return ValidationProblem(UserValidatorMessage.mailExists, null, 442);
            }           
        }

        [Authorize]
        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, User UserIn)
        {
            var User = _UserService.Get(id);

            if (User == null)
            {
                return NotFound();
            }

            _UserService.Update(id, UserIn);

            return NoContent();
        }

 
    }   
}
