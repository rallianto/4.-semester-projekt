using JobAndOffer.Core.Interfaces;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace JobAndOffer.Core.Models
{
    public class Project : IMongoModel
    {
        [BsonId]
        public Guid Id { get; set; }
        public List<Offer> Offers { get; set; }
        public string ProjectDescription { get; set; }
        public string ProjectTitel { get; set; }
        public List<Image> Images { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ExpireDate { get; set; }
        public Provinces Province { get; set; }
        public List<JobTypes> JobType { get; set; }
    }

    public enum Provinces
    {
        [Display(Name = "Københavns By")]
        KøbenhavnsBy = 0,

        [Display(Name = "Københavns omegn")]
        KøbenhavnsOmegn = 1,

        [Display(Name = "Nordsjælland")]
        Nordsjælland = 2,

        [Display(Name = "Bornholm")]
        Bornholm = 3,

        [Display(Name = "Østsjælland")]
        Østsjælland = 4,

        [Display(Name = "Vest- & Sydsjælland")]
        VestOgSydsjælland = 5,

        [Display(Name = "Fyn")]
        Fyn = 6,

        [Display(Name = "Sydjylland")]
        Sydjylland = 7,

        [Display(Name = "Vestjylland")]
        Vestjylland = 8,

        [Display(Name = "Østjylland")]
        Østjylland = 9,

        [Display(Name = "Nordjylland")]
        Nordjylland = 10,
    }

    public enum JobTypes
    {
        Murer = 0,
        Tømrer = 1,
        VVS = 2,
        Elektriker = 3,
        Transport = 4,
        Andet = 5
    }

}
