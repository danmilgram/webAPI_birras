using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace webAPI_birras.Models
{
    public abstract class Person
    {
        [Required]
        [BsonElement("Name")]
        public string name { get; set; }
        
        [Required]
        public string surName { get; set; }

        [Required]
        public string mail { get; set; }

        [Required]
        public int phone { get; set; }
    }
}
