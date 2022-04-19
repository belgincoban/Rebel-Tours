using System;
using System.Collections.Generic;
using System.Text;

namespace RebelTours.Management.Application.BusModels
{
    public class BusModelDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int BusManufacturerId { get; set; }
        public BusType Type { get; set; }
        public int SeatCapacity { get; set; }
        public bool HasToilet { get; set; }

        // sadece verilere değer taşıma amacımız olduğu için setleri açık oldu. 

    }
}
