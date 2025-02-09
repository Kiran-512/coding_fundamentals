using All.Design.Patterns.Creational_Patterns.Builder_Pattern.Builder;
using All.Design.Patterns.Creational_Patterns.Builder_Pattern.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace All.Design.Patterns.Creational_Patterns.Builder_Pattern.Concrete_Builder
{
    public class CarBuilder : ICarBuilder
    {
        private Car _car;
        public CarBuilder()
        {
            _car = new Car();
        }
        public Car Build()
        {
            return _car;
        }

        public ICarBuilder WithEngine(string engine)
        {
            _car.Engine = engine;
            return this;
        }

        public ICarBuilder WithGPS(bool hasGPS)
        {
            _car.HasGPS = hasGPS;
            return this;
        }

        public ICarBuilder WithSunroof(bool hasSunroof)
        {
            _car.HasSunroof = hasSunroof;
            return this;
        }

        public ICarBuilder WithTransmission(string transmission)
        {
            _car.Transmission = transmission;
            return this;
        }
    }
}
