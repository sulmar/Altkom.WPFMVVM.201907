using System;
using System.Collections.Generic;
using System.Text;

namespace SWOP.Transport.Models
{
    public abstract class Employee : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Email { get; set; }
        public string Phone { get; set; }
        public string CellPhone { get; set; }

        public string UserName { get; set; }
        public string HashPassword { get; set; }

        public void Print() => Console.WriteLine(FullName);

        public string FullName => $"{FirstName} {LastName}";

        public IList<Vehicle> Vehicles { get; set; }


        public Employee()
        {
            CreatedAt = DateTime.Now;
        }


        public virtual decimal Calculate()
        {
            return 10;
        }
    }
}
