using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RebelTours.Domain
{
    public class Bus
    {
        public Bus(
            int busId,
            int busModelId,
            string registrationPlate,
            short year,
            SeatingType seatMapping,
            int distanceTraveled)
        {
            BusId = busId;
            BusModelId = busModelId;
            RegistrationPlate = registrationPlate;
            Year = year;
            SeatMapping = seatMapping;
            DistanceTraveled = distanceTraveled;
        }

        public int BusId { get; set; }

        public string RegistrationPlate { get; }

        public short Year { get; }
        public SeatingType SeatMapping { get; set; }

        public int SeatCount
        {
            get
            {
                return BusModel.SeatTemplate.GetSeatCount(SeatMapping);
            }
        }

        public int DistanceTraveled { get; set; }

        public int BusModelId { get; }

        public BusModel BusModel { get; set; }

    }

}

