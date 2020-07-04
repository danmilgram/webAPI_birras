using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace webAPI_birras.Models
{
    public class MeetUp
    {
        [Required]
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [Required]
        [BsonElement("Name")]
        public string name { get; set; }

        [Required]
        public string description { get; set; }

        [Required]
        public DateTime date { get; set; }

        public List<Guest> guests { get; set; }

    }
}
