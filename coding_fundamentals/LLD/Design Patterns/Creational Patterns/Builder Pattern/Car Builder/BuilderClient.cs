using All.Design.Patterns.Creational_Patterns.Builder_Pattern.Builder;
using All.Design.Patterns.Creational_Patterns.Builder_Pattern.Concrete_Builder;
using All.Design.Patterns.Creational_Patterns.Builder_Pattern.Director;
using All.Design.Patterns.Creational_Patterns.Builder_Pattern.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace All.Design.Patterns.Creational_Patterns.Builder_Pattern
{
    public class BuilderClient
    {
        public static void main()
        {
            ICarBuilder builder = new CarBuilder();
            Car car1 = builder
                       .WithEngine("V6")
                       .WithTransmission("Automatic")
                       .WithGPS(true)
                       .WithSunroof(true)
                       .Build();

            CarDirector director = new CarDirector();

            Car sportsCar = director.ConstructSportsCar(builder);
            Car suvCar = director.ConstructSUV(builder);
        }
    }
}
