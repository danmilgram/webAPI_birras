using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace webAPI_birras.Models
{
    public class User : Person
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [Required]
        public string password { get; set; }
        [Required]
        [BsonDefaultValueAttribute( false)]
        public string role { get; set; }

        public List<UserNotification> notifications { get; set; }

    }
}
