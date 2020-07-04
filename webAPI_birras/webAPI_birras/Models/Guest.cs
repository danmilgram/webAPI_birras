using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace webAPI_birras.Models
{
    public class Guest
    {
        [Required]
        [EmailAddress]
        public string mail { get; set; }
        [Required]
        public bool accepted { get; set; }
        [Required]
        public bool checkedIn { get; set; }

    }
}
