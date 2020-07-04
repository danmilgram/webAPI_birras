using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace webAPI_birras.Models.requestModels
{
    public class reqLogin
    {
        [EmailAddress]
        [Required]
        public string mail { get; set; }
        [Required]
        public string password { get; set; }
    }
}
