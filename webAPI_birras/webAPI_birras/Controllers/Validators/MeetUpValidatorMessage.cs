using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webAPI_birras.Controllers.Validators
{
    public class MeetUpValidatorMessage
    {
        public const string isFinalized = "La meetUp ingresada se encuentra finalizada";
        public const string emptyForecast = "No pudimos obtener la previsión de clima para la meetUp solicitada.Por favor volvé a intentarlo al estar más cercana la fecha.";
        public const string isNotFinalized = "La meetUp ingresada no se encuentra finalizada";
        public const string weatherOk = "weatherOK";
        public const string noGuests = "La MeetUp seleccionada aún no tiene invitados";
    }
}
