using System;

namespace SWOP.Transport.Models.Reports
{
    public abstract class ReportBase : Base
    {
        protected ReportBase(string name, string description)
        {
            Name = name;
            Description = description;
            CreateOn = DateTime.Now;
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreateOn { get; set; }
    }
}
