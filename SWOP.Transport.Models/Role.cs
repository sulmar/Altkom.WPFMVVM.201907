using System;
using System.Collections.Generic;
using System.Text;

namespace SWOP.Transport.Models
{
    public class Role : BaseEntity
    {
        public Role()
        {

        }

        public Role(string name)
        {
            Name = name;
        }

        public string Name { get; set; }

        public ICollection<Employee> Employees { get; set; }
    }
}
