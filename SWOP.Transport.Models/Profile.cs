using System;
using System.Collections.Generic;
using System.Text;

namespace SWOP.Transport.Models
{
    public class Profile : BaseEntity
    {
        public string Name { get; set; }
        public string ConnectionString { get; set; }
    }
}
