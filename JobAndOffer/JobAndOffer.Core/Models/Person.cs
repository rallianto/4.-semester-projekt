using JobAndOffer.Core.Interfaces;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace JobAndOffer.Core.Models
{
    [DataContract]
    public abstract class Person : IMongoModel
    {
        public Person(string FirstName, string LastName, string City, int ZipCode, string Phone, string Email)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.City = City;
            this.ZipCode = ZipCode;
            this.Phone = Phone;
            this.Email = Email;
        }

        [DataMember, BsonId]
        //[BsonRepresentation(BsonType.ObjectId)]
        public Guid Id { get; set; }

        [DataMember]
        public string FirstName { get; set; }

        [DataMember]
        public string LastName { get; set; }

        [DataMember]
        public string City { get; set; }

        [DataMember]
        public int ZipCode { get; set; }

        [DataMember]
        public string Phone { get; set; }

        [DataMember]
        public string Email { get; set; }
    }
}