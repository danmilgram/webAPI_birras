using Microsoft.AspNetCore.Mvc;
using webAPI_birras.Controllers.Validators;
using webAPI_birras.Models;
using webAPI_birras.Models.requestModels;
using webAPI_birras.Services;

namespace webAPI_birras.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserService _userService;
        private readonly AuthService _authService;

        public AuthController( UserService userService, AuthService authService)
        {
            _userService = userService;
            _authService = authService;
        }

        [HttpPost]
        public ActionResult Login([FromBody] reqLogin req)
        {
            User user = _userService.GetByMail(req.mail);
            var pass = _authService.SecurePassword(req.password);

            string msg = UserValidator.LoginValidator(user, pass);

            if (msg == UserValidatorMessage.okLogin)
            {
                string token = _authService.GrantAccess(user);

                return Ok("Bearer Auth Token:" + token);
            }
            else
            {
                return Unauthorized();
            }

        }
    }
}
