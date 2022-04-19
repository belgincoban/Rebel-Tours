using System;
using System.Collections.Generic;
using System.Text;

namespace RebelTours.Domain
{
   public class BusModel
    {
        public BusModel(int id, string name, int busManufacturerId, BusType type, int seatCapacity, bool hasToilet )
        {
            Id = id;
            Name = name;
            Type = type;
            BusManufacturerId = busManufacturerId;
            SeatCapacity = seatCapacity;
            HasToilet = hasToilet;
            SeatTemplate = CreateSeatTemplate(Type, SeatCapacity);

        }

        private SeatTemplate CreateSeatTemplate(BusType type, int seatCapacity)
        {
            if (type == BusType.Coach)
            {
                return CreateCoachSeatTemplate(seatCapacity);
            }
            else if (type == BusType.Shuttle)
            {
                return CreateShuttleSeatTemplate(seatCapacity);
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(type));
            }
        }

        private SeatTemplate CreateShuttleSeatTemplate(int seatCapacity)
        {
            var rowCountDictionary = new Dictionary<int, int>()
            {
                [26] = 7,
                [28] = 8,
                [30] = 9
            };

            var activeRowCount = rowCountDictionary.ContainsKey(seatCapacity)
                ? rowCountDictionary[seatCapacity]
                : 0;

            return new SeatTemplate(
                rowCount: 9,
                colCount: 4,
                activeRowCount,
                2, 3, 30,31,34,35);
        }

        private SeatTemplate CreateCoachSeatTemplate(int seatCapacity)
        {
            int activeRowCount;

            switch (seatCapacity)
            {
                case 44:
                    activeRowCount = 12;
                    break;
                case 48:
                    activeRowCount = 13;
                    break;
                case 52:
                    activeRowCount = 14;
                    break;
                default:
                    activeRowCount = 0;
                    break;
            }

            return new SeatTemplate(
                rowCount: 14,
                colCount: 4,
                activeRowCount,
                22, 23, 26, 27);
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int BusManufacturerId { get; }
        public BusType Type { get; }
        public int SeatCapacity { get;}
        public SeatTemplate SeatTemplate { get; }
        public bool HasToilet { get;}
        public BusManufacturer BusManufacturer { get; set; }



    }
}
