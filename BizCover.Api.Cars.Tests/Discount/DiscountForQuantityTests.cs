using AutoFixture;
using BizCover.Api.Cars.Services.Discount;
using FluentAssertions;
using NUnit.Framework;
using System.Linq;


namespace BizCover.Api.Cars.Tests.Discount
{
    class DiscountForQuantityTests
    {
        private DiscountForQuantity _sut;

        private Fixture _fixture;

        [SetUp]
        public void Setup()
        {
            _sut = new DiscountForQuantity();
            _fixture = new Fixture();
        }

        [Test]
        public void Given_MoreThan2Cars_Should_Apply3PercentDiscount()
        {
            var cars = _fixture.CreateMany<Repository.Cars.Car>(3).ToList();
            cars[0].Price = 100M;
            cars[1].Price = 200M;
            cars[2].Price = 300M;

            var discount = _sut.CalculateDiscount(cars);

            discount.Should().Be(18M);
        }

        [Test]
        public void Given_LessThan2Cars_Should_NotApplyAnyDiscount()
        {
            var cars = _fixture.CreateMany<Repository.Cars.Car>(2).ToList();

            var discount = _sut.CalculateDiscount(cars);

            discount.Should().Be(0M);
        }
    }
}
