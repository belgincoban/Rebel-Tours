﻿using System;
using System.Collections.Generic;
using System.Text;

namespace RebelTours.Management.Application.Buses
{
    public class BusSummaryDTO
    {
        public int BusId { get; set; }
        public string BusModelName { get; set; }
        public string RegistrationPlate { get; set; }
        public short Year { get; set; }
        public SeatingType SeatMapping { get; set; }
        public int SeatCount { get; set; }
        public int DistanceTraveled { get; set; }
    }
}
