using BizCover.Api.Cars.Services.AddCar;
using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BizCover.Api.Cars.Tests.AddCar
{
    [TestFixture]
    public class AddCarRequestTests
    {

        [TestCase(arguments: new object[] { "", "Australia", "Honda", "Sedan", 10000, 2019 }, TestName = "Color missing")]
        [TestCase(arguments: new object[] { "abcdefghiabcdefghiabcdefghiabcdefghiabcdefghiabcdaa", "Australia", "Honda", "Sedan", 10000, 2019 }, TestName = "Color too long")]

        [TestCase(arguments: new object[] { "White", "", "Honda", "Sedan", 10000, 2019 }, TestName = "Country missing")]
        [TestCase(arguments: new object[] { "White", "abcdefghiabcdefghiabcdefghiabcdefghiabcdefghiabcdaa", "Honda", "Sedan", 10000, 2019 }, TestName = "Country too long")]
        public void Given_InvalidPropertyValues_Returns_InvalidValue(params object[] args)
        {
            var request = new AddCarRequest
            {
                Colour = args[0]?.ToString(),
                CountryManufactured = args[1]?.ToString(),
                Make = args[2]?.ToString(),
                Model = args[3]?.ToString(),
                Price = args[4] == null ? 0M : decimal.Parse(args[4].ToString()),
                Year = args[5] == null ? 0 : int.Parse(args[5].ToString())
            };

            var context = new ValidationContext(request);
            var validationResults = new List<ValidationResult>();
            var result = Validator.TryValidateObject(request, context, validationResults, true);

            result.Should().BeFalse();
        }
    }

}
