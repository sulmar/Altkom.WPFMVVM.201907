using System;
using System.Collections.Generic;
using System.Text;

namespace SWOP.Transport.Models
{
    public class Deadline : BaseEntity
    {
        public DateTime Date { get; set; }
        public DeadlineType Type { get; set; }
    }

    public enum DeadlineType
    {
        OC,
        AC,
        NNW,
        OT1,
        OT2
    }
}
