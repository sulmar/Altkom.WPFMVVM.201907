using System;
using System.Collections.Generic;
using System.Text;

namespace SWOP.Transport.Models
{
    public abstract class Employee : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }


        public virtual decimal Calculate()
        {
            return 10;
        }
    }
}
