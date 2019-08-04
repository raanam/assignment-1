using BizCover.Api.Cars.Common;
using System.ComponentModel.DataAnnotations;

namespace BizCover.Api.Cars.Services.UpdateCar
{
    public class UpdateCarRequest : IUpdateCarRequest
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int Id { get; set; }

        [Required()]
        [StringLength(50)]
        public string Colour { get; set; }

        [Required()]
        [StringLength(50)]
        public string CountryManufactured { get; set; }

        [Required()]
        [StringLength(50)]
        public string Make { get; set; }

        [Required()]
        [StringLength(50)]
        public string Model { get; set; }

        [Required()]
        [Range(100, int.MaxValue)]
        public decimal Price { get; set; }

        [Required()]
        [YearValidator()]
        public int Year { get; set; }
    }
}
