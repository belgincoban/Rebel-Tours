using System;
using System.Collections.Generic;
using System.Text;

namespace RebelTours.Domain
{
    public class City
    {
        public City()
        {
            Stations = new List<Station>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Station> Stations { get; set; }

    }
}
