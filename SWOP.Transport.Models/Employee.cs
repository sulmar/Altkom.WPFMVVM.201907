using System;
using System.Collections.Generic;
using System.Text;

namespace SWOP.Transport.Models
{
    public abstract class Employee : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public void Print() => Console.WriteLine(FullName);

        public string FullName => $"{FirstName} {LastName}";



        public virtual decimal Calculate()
        {
            return 10;
        }
    }
}
