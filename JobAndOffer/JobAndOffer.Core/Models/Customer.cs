using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace JobAndOffer.Core.Models
{
    [DataContract]
    public class Customer : Person
    {
        public Customer (string FirstName, string LastName, string City, int ZipCode, string Phone, string Email)
            : base(FirstName, LastName, City, ZipCode, Phone, Email)
        {

        }
    }
}
