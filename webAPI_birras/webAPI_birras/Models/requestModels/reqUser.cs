using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace webAPI_birras.Models.requestModels
{
    public class reqUser
    {
        [Required]
        public string name { get; set; }

        [Required]
        public string surName { get; set; }

        [EmailAddress]
        [Required]
        public string mail { get; set; }

        [Required]
        public int phone { get; set; }

        [Required]
        public string password { get; set; }
    }
}
