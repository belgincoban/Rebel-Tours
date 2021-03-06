using System;
using System.Collections.Generic;
using System.Text;

namespace RebelTours.Management.Application.BusModels
{
    public class BusModelSummaryDTO
    {
 
        public int Id { get; set; }
        public string Name { get; set; }
        public string BusManufacturerName { get; set; }
        public BusType Type { get; set; }
        public int SeatCapacity { get; set; }
        public bool HasToilet { get; set; }
        public string HasToiletString { get { return HasToilet ? "Var" : "Yok"; } }
    }
}

