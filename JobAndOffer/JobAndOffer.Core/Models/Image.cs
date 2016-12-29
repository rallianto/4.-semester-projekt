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
    public class Image : IMongoModel
    {
        [DataMember, BsonId]
        public Guid Id { get; set; }

        [DataMember]
        public byte[] ImageBytes { get; set; }

        [DataMember]
        public string ImageName { get; set; }

        [BsonIgnore]
        public Project Project { get; set; }

        [DataMember, BsonIgnore]
        public Guid ProjectId { get; set; }
    }
}