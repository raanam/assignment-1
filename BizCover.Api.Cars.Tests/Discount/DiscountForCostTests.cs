using AutoFixture;
using BizCover.Api.Cars.Services.Discount;
using FluentAssertions;
using NUnit.Framework;
using System.Linq;

namespace BizCover.Api.Cars.Tests.Discount
{
    [TestFixture]
    public class DiscountForCostTests
    {
        private DiscountForCost _sut;

        private Fixture _fixture;

        [SetUp]
        public void Setup()
        {
            _sut = new DiscountForCost();
            _fixture = new Fixture();
        }

        [Test]
        public void Given_CostMoreThan100000_Should_Apply5PercentDiscount()
        {
            var cars = _fixture.CreateMany<Repository.Cars.Car>(2).ToList();
            cars[0].Price = 150000;
            cars[1].Price = 200000;

            var discount = _sut.CalculateDiscount(cars);

            discount.Should().Be(17500M);
        }

        [Test]
        public void Given_CostLessThan100000_Should_NotApplyAnyDiscount()
        {
            var cars = _fixture.CreateMany<Repository.Cars.Car>(2).ToList();
            cars[0].Price = 99999;
            cars[1].Price = 50000;

            var discount = _sut.CalculateDiscount(cars);

            discount.Should().Be(0M);
        }
    }
}
