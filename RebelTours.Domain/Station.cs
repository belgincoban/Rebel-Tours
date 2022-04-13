using System;
using System.Collections.Generic;
using System.Text;

namespace RebelTours.Domain
{
    public class Station
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }

    }
}
