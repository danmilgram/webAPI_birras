using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webAPI_birras.Models;

namespace webAPI_birras.Controllers.Validators
{
    public class UserValidator
    {
        public static string LoginValidator(User user, string pass)
        {
            if (user != null && user.password == pass)
            {
                return UserValidatorMessage.okLogin;                
            }
            else
            {
                return UserValidatorMessage.cantLogin;
            }
        }
    }
}
