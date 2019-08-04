using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BizCover.Repository.Cars;

namespace BizCover.Api.Cars.Services.UpdateCar
{
    public class UpdateCarRequestMapper : IUpdateCarRequestMapper
    {
        public Car Map(IUpdateCarRequest updateCarRequest)
        {
            return new Car
            {
                Id = updateCarRequest.Id,
                Colour = updateCarRequest.Colour,
                CountryManufactured = updateCarRequest.CountryManufactured,
                Make = updateCarRequest.Make,
                Model = updateCarRequest.Model,
                Price = updateCarRequest.Price,
                Year = updateCarRequest.Year
            };
        }
    }
}