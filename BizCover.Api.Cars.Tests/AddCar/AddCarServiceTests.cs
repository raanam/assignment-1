using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoFixture;
using FluentAssertions;
using AutoFixture.AutoNSubstitute;
using BizCover.Api.Cars.Services.AddCar;
using BizCover.Repository.Cars;
using NSubstitute;
using BizCover.Api.Cars.CarRepositoryCache;

namespace BizCover.Api.Cars.Tests.AddCar
{
    [TestFixture]
    public class AddCarServiceTests
    {
        private Fixture _fixture;

        private AddCarService _sut;

        private ICarRepository _carRepository;

        private IAddCarRequestMapper _requestMapper;

        private ICarRepositoryCache _carRepositoryCache;

        [SetUp]
        public void Setup()
        {
            _fixture = (Fixture)new Fixture().Customize(new AutoNSubstituteCustomization());

            _carRepository = _fixture.Freeze<ICarRepository>();
            _requestMapper = _fixture.Freeze<IAddCarRequestMapper>();
            _carRepositoryCache = _fixture.Freeze<ICarRepositoryCache>();

            _sut = _fixture.Create<AddCarService>();
        }

        [Test]
        public async Task Given_ValidCarRequest_Returns_Car()
        {
            // Arrange.
            var carId = _fixture.Create<int>();
            var carToCreate = _fixture.Create<Car>();
            var request = _fixture.Create<AddCarRequest>();

            _carRepository.Add(Arg.Any<Car>()).Returns(carId);
            _requestMapper.Map(Arg.Any<AddCarRequest>()).Returns(carToCreate);

            // Act.
            var response = await _sut.AddCar(request);

            // Assert.
            response.Id.Should().Be(carId);
            _carRepositoryCache.Received(1).InvalidateCache();
        }
    }
}
