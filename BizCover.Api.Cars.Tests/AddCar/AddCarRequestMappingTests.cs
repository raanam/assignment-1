using AutoFixture;
using AutoFixture.AutoNSubstitute;
using BizCover.Api.Cars.Services.AddCar;
using NUnit.Framework;
using FluentAssertions;

namespace BizCover.Api.Cars.Tests.AddCar
{
    [TestFixture]
    public class AddCarRequestMappingTests
    {
        private AddCarRequestMapper _sut;
        private Fixture _fixture;

        [SetUp]
        public void Setup()
        {
            _sut = new AddCarRequestMapper();
            _fixture = (AutoFixture.Fixture) new AutoFixture.Fixture().Customize(new AutoNSubstituteCustomization());
            
        }

        [Test]
        public void Given_AddCarRequest_Returns_MappedCarObject()
        {
            var addCarRequest = _fixture.Create<AddCarRequest>();

            var car = _sut.Map(addCarRequest);

            car.Colour.Should().Be(addCarRequest.Color);
            car.Make.Should().Be(addCarRequest.Make);
            car.Model.Should().Be(addCarRequest.Model);
            car.Year.Should().Be(addCarRequest.Year);
            car.CountryManufactured.Should().Be(addCarRequest.CountryManufactured);
        }
    }
}
