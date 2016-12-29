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
    public class Offer : IMongoModel
    {
        [DataMember, BsonId]
        public Guid Id { get; set; }

        [DataMember]
        public double OfferPrice { get; set; }

        [DataMember]
        public string OfferDescription { get; set; }

        [DataMember]
        public DateTime EstimatedTime { get; set; }

        [DataMember]
        public Project Project { get; set; }

        [DataMember]
        public Worker Worker { get; set; }
    }
}