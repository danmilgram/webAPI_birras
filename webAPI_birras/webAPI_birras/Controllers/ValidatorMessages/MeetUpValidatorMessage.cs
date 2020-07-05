using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webAPI_birras.Controllers.Validators
{
    public class MeetUpValidatorMessage
    {
        public const string isFinalized = "La meetUp ingresada se encuentra finalizada";
        public const string isNotFinalized = "La meetUp ingresada no se encuentra finalizada";
        public const string noGuests = "La MeetUp seleccionada aún no tiene invitados";
        public const string OkGuests = "Ok";
        public const string notInvited = "El usuario ingresado no se encuentra entre los invitados al evento.";
    }
}
