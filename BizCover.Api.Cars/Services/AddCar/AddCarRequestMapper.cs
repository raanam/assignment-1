using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BizCover.Repository.Cars;

namespace BizCover.Api.Cars.Services.AddCar
{
    public class AddCarRequestMapper : IAddCarRequestMapper
    {
        public Car Map(IAddCarRequest request)
        {
            return new Car
            {
                Colour = request.Color,
                CountryManufactured = request.CountryManufactured,
                Make = request.Make,
                Model = request.Model,
                Price = request.Price,
                Year = request.Year
            };
        }
    }
}