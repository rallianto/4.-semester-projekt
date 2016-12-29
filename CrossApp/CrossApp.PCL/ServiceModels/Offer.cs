using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossApp.PCL.ServiceModels
{
    public class Offer
    {
        public Guid Id { get; set; }

        public double OfferPrice { get; set; }
        public string OfferDescription { get; set; }

        public DateTime EstimatedTime { get; set; }

        public Project Project { get; set; }

        public Worker Worker { get; set; }
    }
}
