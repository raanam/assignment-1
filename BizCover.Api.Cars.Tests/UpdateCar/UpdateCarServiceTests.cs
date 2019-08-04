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
using BizCover.Api.Cars.Services.UpdateCar;

namespace BizCover.Api.Cars.Tests.UpdateCar
{
    [TestFixture]
    public class UpdateCarServiceTests
    {
        private Fixture _fixture;

        private UpdateCarService _sut;

        private ICarRepository _carRepository;

        private ICarRepositoryCache _carRepositoryCache;

        private IUpdateCarRequestMapper _requestMapper;

        [SetUp]
        public void Setup()
        {
            _fixture = (Fixture)new Fixture().Customize(new AutoNSubstituteCustomization());

            _carRepository = _fixture.Freeze<ICarRepository>();
            _requestMapper = _fixture.Freeze<IUpdateCarRequestMapper>();
            _carRepositoryCache = _fixture.Freeze<ICarRepositoryCache>();

            _sut = _fixture.Create<UpdateCarService>();
        }

        [Test]
        public async Task Given_ValidCarRequest_UpdatesCar()
        {
            // Arrange.
            var carBeforeUpdate = _fixture.Create<Car>();
            var carAfterUpdate = _fixture.Create<Car>();

            var request = _fixture.Create<UpdateCarRequest>();
            request.Id = carBeforeUpdate.Id;

            _carRepositoryCache.GetAllCars().Returns(new List<Car>() { carBeforeUpdate });
            await _carRepository.Update(Arg.Any<Car>());
            _requestMapper.Map(Arg.Any<UpdateCarRequest>()).Returns(carAfterUpdate);

            // Act.
            var response = await _sut.Update(request);

            // Assert.
            response.Should().Be(carAfterUpdate);
            _carRepositoryCache.Received(1).InvalidateCache();
            _carRepository.Received(1).Update(Arg.Is<Car>(carAfterUpdate));
        }
    }
}
