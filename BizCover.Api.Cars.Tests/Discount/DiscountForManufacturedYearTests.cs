using AutoFixture;
using BizCover.Api.Cars.Services.Discount;
using FluentAssertions;
using NUnit.Framework;
using System.Linq;

namespace BizCover.Api.Cars.Tests.GetAllCars
{
    [TestFixture]
    public class DiscountForManufacturedYearTests
    {
        private DiscountForManufacturedYear _sut;

        private Fixture _fixture;

        [SetUp]
        public void Setup()
        {
            _sut = new DiscountForManufacturedYear();
            _fixture = new Fixture();
        }

        [Test]
        public void Given_YearOfManufactureBefore2000_Should_Apply10PercentDiscount()
        {
            var cars = _fixture.CreateMany<Repository.Cars.Car>(2).ToList();
            cars[0].Price = 100;
            cars[0].Year = 1999;

            cars[1].Price = 200;
            cars[1].Year = 1900;

            var discount = _sut.CalculateDiscount(cars);

            discount.Should().Be(30M);
        }

        [Test]
        public void Given_YearOfManufactureOnOrAfter2000_Should_NotApplyAnyDiscount()
        {
            var cars = _fixture.CreateMany<Repository.Cars.Car>(2).ToList();
            cars[0].Price = 100;
            cars[0].Year = 2000;

            cars[1].Price = 200;
            cars[1].Year = 2001;

            var discount = _sut.CalculateDiscount(cars);

            discount.Should().Be(0M);
        }
    }
}
