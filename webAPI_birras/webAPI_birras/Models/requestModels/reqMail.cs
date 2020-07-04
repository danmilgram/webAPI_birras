using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace webAPI_birras.Models.requestModels
{
    public class reqMail
    {
        [EmailAddress]
        [Required]
        public string mail { get; set; }
    }

    public class reqListMails
    {
        [Required]
        public List<string> mails { get; set; }
    }
}
