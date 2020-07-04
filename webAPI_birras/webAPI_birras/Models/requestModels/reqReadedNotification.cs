using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace webAPI_birras.Models.requestModels
{
    public class reqReadedNotification
    {
        [Required]
        public string id { get; set; }

        [Required]
        [EmailAddress]
        public string mail { get; set; } 
    }
}
