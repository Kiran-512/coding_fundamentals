using All.Design.Patterns.Creational_Patterns.Builder_Pattern.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace All.Design.Patterns.Creational_Patterns.Builder_Pattern.Builder
{
    public interface ICarBuilder
    {
        ICarBuilder WithEngine(string engine);
        ICarBuilder WithGPS(bool hasGPS);
        ICarBuilder WithSunroof(bool hasSunroof);
        ICarBuilder WithTransmission(string transmission);
        Car Build(); // Returns the final product
    }
}
