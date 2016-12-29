using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossApp.PCL.ServiceModels
{
    public class Worker : Person
    {
        public Worker(string Username, string Password,
            string FirstName, string LastName, string City, int ZipCode, string Phone, string Email)
            : base(FirstName, LastName, City, ZipCode, Phone, Email)
        {
            this.Username = Username;
            this.Password = Password;
        }
        public string Username { get; set; }

        public string Password { get; set; }

        public List<Offer> Offers { get; set; }
    }
}
