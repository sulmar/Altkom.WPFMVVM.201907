using System;

namespace SWOP.Transport.Models
{
    public class Vehicle : BaseEntity
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public string PlateNumber { get; set; }
        public bool IsRemoved { get; set; }
        public DateTime CreatedAt { get; set; }
        public VehicleType Type { get; set; }

        public Employee Owner { get; set; }

        public Vehicle()
        {
            CreatedAt = DateTime.Now;
        }
    }

    public enum VehicleType
    {
        SUV,
        Sedan,
        Kombi
    }

}
