using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webAPI_birras.Models
{
    public class Invitation
    {
        public const string Subject = "Has sido invitado a un evento!";
        
        public static string getText (MeetUp meet)
        {
            return "Has sido invitado al evento " + meet.name + " a realizarse el día " + meet.date + ". <BR><BR><BR> Resumen del evento: " + meet.description + ". <BR><BR><BR> Para participar podés confirmarnos tu asistencia desde nuestra plataforma. Te esperamos!!";
        }
    }
}
