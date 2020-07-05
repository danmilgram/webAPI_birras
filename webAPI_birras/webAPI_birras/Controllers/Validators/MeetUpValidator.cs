using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webAPI_birras.Models;
using webAPI_birras.Services;

namespace webAPI_birras.Controllers.Validators
{
    public class MeetUpValidator
    {

        public static bool ValidateFin(MeetUp meet)
        {
            if (DateTime.Now > meet.date)
            {
                return true;
            }
            else 
            {
                return false;
            }
        }


        public static string ValidateGuest(MeetUp meet)
        {
            if (meet.guests.Count == 0)
            {
                return MeetUpValidatorMessage.noGuests;
            }
            else
            {
                return MeetUpValidatorMessage.OkGuests;
            }
                        
        }
    }
}
