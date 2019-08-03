using BizCover.Api.Cars.Common;
using System.ComponentModel.DataAnnotations;

namespace BizCover.Api.Cars.Services.AddCar
{
    public class AddCarRequest : IAddCarRequest
    {
        [Required()]
        [MaxLength(50)]
        public string Color { get; set; }

        [Required()]
        [MaxLength(50)]
        public string CountryManufactured { get; set; }

        [Required()]
        [MaxLength(50)]
        public string Make { get; set; }

        [Required()]
        [MaxLength(50)]
        public string Model { get; set; }

        [Required()]
        [Range(100, int.MaxValue)]
        public decimal Price { get; set; }

        [Required()]
        [YearValidator()]
        public int Year { get; set; }
    }
}