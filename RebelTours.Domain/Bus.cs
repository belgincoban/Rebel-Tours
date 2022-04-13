using System;
using System.Collections.Generic;
using System.Text;

namespace RebelTours.Domain
{
    public class Bus
    {
        public Bus(int id, int busModelId, string registrationPlate, short year,int seatCount, SeatingType seatMapping,int distanceTraveled)
        {
            Id = id;
            BusModelId = busModelId;
            RegistrationPlate = registrationPlate;
            SeatMapping = seatMapping;
            SeatCount = seatCount;
            Year = year;
            DistanceTraveled = distanceTraveled;
        }
        public int Id { get; set; }
        public int BusModelId { get; }
        public string RegistrationPlate { get; }
        public short Year { get;}
        public SeatingType SeatMapping { get; set; }
        public int SeatCount { get; set; }
         
            //get
            //{
            //    if (BusModel.Type == BusType.Coach)
            //    {
            //        if (BusModel.SeatCapacity == 52)
            //        {
            //            var SeatCapacityCount =

            //            if (true)
            //            {

            //            }
            //        }
            //    }
            //} 
        
        public int DistanceTraveled { get; set; }
        public BusModel BusModel { get; set; }

    }
}
