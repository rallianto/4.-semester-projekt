using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossApp.PCL.ServiceModels
{
    public abstract class Person
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

        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string City { get; set; }

        public int ZipCode { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }
    }
}
