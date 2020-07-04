using System.ComponentModel.DataAnnotations;

namespace webAPI_birras.Models.requestModels
{
    public class reqNotification
    {
        [Required]
        public string text { get; set; }

        public reqListMails users {get; set;}



    }
}
