using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace JobAndOffer.Core.Models
{
    [DataContract]
    public class Worker : Person
    {
        public Worker(string Username, string Password,
            string FirstName, string LastName, string City, int ZipCode, string Phone, string Email)
            : base(FirstName, LastName, City, ZipCode, Phone, Email)
        {
            this.Username = Username;
            this.Password = Password;
        }
        [DataMember]
        public string Username { get; set; }

        [DataMember]
        public string Password { get; set; }

        [BsonIgnore]
        public List<Offer> Offers { get; set; }

        public static implicit operator UpdateDefinition<object>(Worker v)
        {
            throw new NotImplementedException();
        }
    }
}