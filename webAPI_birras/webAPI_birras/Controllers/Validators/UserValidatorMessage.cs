using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webAPI_birras.Controllers.Validators
{
    public class UserValidatorMessage
    {
        public const string cantLogin = "Usuario o password incorrectos.";
        public const string okLogin = "Ok";
        public const string mailExists = "El mail ingresado ya se encuentra registrado";
    }
}
