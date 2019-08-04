using AutoFixture;
using AutoFixture.AutoNSubstitute;
using BizCover.Api.Cars.Services.GetAllCars;
using BizCover.Repository.Cars;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;
using FluentAssertions;
using BizCover.Api.Cars.CarRepositoryCache;
using BizCover.Api.Cars.Services.Discount;
using System.Web;
using System.Web.Http;

namespace BizCover.Api.Cars.Tests.Discount
{
    [TestFixture]
    public class DiscountCalculatorServiceTests
    {
        private Fixture _fixture;

        private ICarRepositoryCache _carRepositoryCache;

        private IDiscountCalculator _discountCalculator1;

        private IDiscountCalculator _discountCalculator2;

        private IDiscountCalculatorService _sut;

        [SetUp]
        public void Setup()
        {
            _fixture = (Fixture)new Fixture().Customize(new AutoNSubstituteCustomization());

            _carRepositoryCache = NSubstitute.Substitute.For<ICarRepositoryCache>();
            _discountCalculator1 = NSubstitute.Substitute.For<IDiscountCalculator>();
            _discountCalculator2 = NSubstitute.Substitute.For<IDiscountCalculator>();

            _sut = new DiscountCalculatorService(_carRepositoryCache, new List<IDiscountCalculator> { _discountCalculator1, _discountCalculator2 });
        }

        [Test]
        public async Task Given_InvalidCarsToPurchase_Should_ThrowException()
        {
            var cars = _fixture.CreateMany<Repository.Cars.Car>(3).ToList();

            cars[0].Id = 1;
            cars[1].Id = 2;
            cars[2].Id = 3;

            _carRepositoryCache.GetAllCars().Returns(cars);

            // Act.
            Assert.ThrowsAsync<HttpResponseException>(async () => await _sut.CalculateDiscount(new List<int> { 1, 2, 3, 4 }));
        }

        [Test]
        public async Task Given_ValidCarsToPurchase_Should_GiveSumOfDiscountsFromAllConditions()
        {
            var cars = _fixture.CreateMany<Repository.Cars.Car>(3).ToList();

            cars[0].Id = 1;
            cars[1].Id = 2;
            cars[2].Id = 3;

            _carRepositoryCache.GetAllCars().Returns(cars);

            _discountCalculator1.CalculateDiscount(Arg.Any<IReadOnlyList<Repository.Cars.Car>>()).Returns(100M);
            _discountCalculator2.CalculateDiscount(Arg.Any <IReadOnlyList<Repository.Cars.Car>>()).Returns(300M);

            // Act.
            var response = await _sut.CalculateDiscount(new List<int> { 1, 2, 3 });

            // Assert.
            response.Discount.Should().Be(400M);
        }
    }
}
