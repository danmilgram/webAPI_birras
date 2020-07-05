using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webAPI_birras.Controllers.Validators
{
    public class WeatherValidatorMessage
    {
        public const string emptyForecast = "No pudimos obtener la previsión de clima para el día solicitado.Por favor volvé a intentarlo al estar más cercana la fecha.";
        public const string weatherOk = "weatherOK";
    }
}
