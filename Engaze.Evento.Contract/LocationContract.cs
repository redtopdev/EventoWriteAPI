using System;
using System.Collections.Generic;
using System.Text;

namespace Engaze.Evento.Contract
{
    public class LocationContract
    {
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }
}
