using Microsoft.AspNetCore.Mvc;
using webAPI_birras.Models.requestModels;
using webAPI_birras.Models;
using webAPI_birras.Services;
using webAPI_birras.Helpers;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

namespace webAPI_birras.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly UserService _userService;
        private readonly NotificationService _notService;

        public NotificationController(UserService userService, NotificationService notService)
        {
            _userService = userService;
            _notService = notService;            
        }

        [Authorize]
        [HttpPut("/api/notification/read")]
        public ActionResult Read([FromBody] reqReadedNotification req)
        {
            var user = _userService.GetByMail(req.mail);

            if (user == null)
            {
                return NotFound();
            }
            else
            {
                foreach (var n in user.notifications)
                {
                    if (n.Id == req.id)
                    {
                        n.readed = true;
                        _userService.Update(user.Id, user);
                    }
                }
                return Ok(user.notifications);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult<List<Notification>> Get() =>
        _notService.Get();

        [Authorize(Roles = "Admin")]
        [HttpPost("/api/notification/send")]
        public ActionResult Send([FromBody] reqNotification req)
        {
            Notification not = new Notification
            {
                Id = TypeHelpers.GetRandomHexNumber(24),
                text = req.text
            };

            _notService.Create(not);

            int sended = 0;
            foreach (var m in req.users.mails)
            {
                var user = _userService.GetByMail(m);

                if (user != null)
                {
                    UserNotification un = new UserNotification
                    {
                        Id = not.Id,
                        text = not.text,
                        readed = false
                    };
                    user.notifications.Add(un);
                    _userService.Update(user.Id,user);                    
                    sended++;
                }
            }
            return Ok("Notificaciones enviadas exitosamente: " + sended.ToString());
        }
    }
}
