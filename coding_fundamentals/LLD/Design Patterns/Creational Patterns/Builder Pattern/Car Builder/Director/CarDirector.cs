using All.Design.Patterns.Creational_Patterns.Builder_Pattern.Builder;
using All.Design.Patterns.Creational_Patterns.Builder_Pattern.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace All.Design.Patterns.Creational_Patterns.Builder_Pattern.Director
{
    public class CarDirector
    {
        public Car ConstructSportsCar(ICarBuilder _builder)
        {
            return _builder.WithEngine("S8")
                        .WithGPS(true)
                        .WithSunroof(true)
                        .WithTransmission("Manual")
                        .Build();
        }

        public Car ConstructSUV(ICarBuilder _builder)
        {
            return _builder.WithEngine("S6")
                        .WithGPS(true)
                        .WithSunroof(true)
                        .WithTransmission("Autmation")
                        .Build();
        }

    }
}
