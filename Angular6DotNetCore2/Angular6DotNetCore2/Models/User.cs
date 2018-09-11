using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Angular6DotNetCore2.Models
{
    public class User
    {
        public ObjectId Id { get; set; }
        [BsonElement("last_name")]
        public string LastName { get; set; }
        [BsonElement("first_name")]
        public string FirstName { get; set; }        
    }
}
