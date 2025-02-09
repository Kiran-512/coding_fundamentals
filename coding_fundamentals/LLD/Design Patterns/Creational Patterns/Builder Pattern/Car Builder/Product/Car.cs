using System;
using System.Collections.Generic;
using System.Text;

namespace All.Design.Patterns.Creational_Patterns.Builder_Pattern.Product
{
    public class Car
    {
        public string Engine { get; set; }
        public bool HasGPS { get; set; }
        public bool HasSunroof { get; set; }
        public string Transmission { get; set; }

        public override string ToString()
        {
            return $"Car with {Engine} engine, Transmission: {Transmission}, GPS: {HasGPS}, Sunroof: {HasSunroof}";
        }
    }
}
