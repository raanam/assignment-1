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

namespace BizCover.Api.Cars.Tests.GetAllCars
{
    [TestFixture]
    public class GetAllCarsServiceTest
    {
        private Fixture _fixture;

        private GetAllCarsService _sut;

        private ICarRepositoryCache _carRepository;


        [SetUp]
        public void Setup()
        {
            _fixture = (Fixture)new Fixture().Customize(new AutoNSubstituteCustomization());

            _carRepository = _fixture.Freeze<ICarRepositoryCache>();

            _sut = _fixture.Create<GetAllCarsService>();
        }

        [Test]
        public async Task Given_ValidCarRequest_Returns_Car()
        {
            // Arrange.
            var cars = _fixture.CreateMany<Car>(5).ToList();

            _carRepository.GetAllCars().Returns(cars);

            // Act.
            var response = await _sut.GetAllCars();

            // Assert.
            response.Count().Should().Be(cars.Count);
            cars.ForEach(c => response.Should().Contain(c));
        }
    }
}
