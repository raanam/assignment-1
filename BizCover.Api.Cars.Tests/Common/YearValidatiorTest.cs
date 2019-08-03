using BizCover.Api.Cars.Common;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using System.ComponentModel.DataAnnotations;

namespace BizCover.Api.Cars.Tests.Common
{
    [TestFixture]
    public class YearValidatiorTest
    {
        private YearValidator _sut;

        [SetUp]
        public void Setup()
        {
            _sut = new YearValidator();
        }

        [TestCase(null)]
        [TestCase("Test")]
        public void Given_InvalidYear_Returns_InvalidValue(object value)
        {
            var context = new ValidationContext("Test");
            var result = _sut.GetValidationResult(value, context);

            result.ErrorMessage.Should().Be(YearValidator.InvalidValue);
        }

        [Test]
        public void Given_FutureYear_Returns_YearCannotBeInFuture()
        {
            // Arrange
            var currentYear = DateTime.UtcNow.Year;
            var context = new ValidationContext("Test");

            // Act
            var result = _sut.GetValidationResult(currentYear + 1, context);

            // Assert.
            result.ErrorMessage.Should().Be(YearValidator.YearCannotBeFuture);
        }

        [Test]
        public void Given_CurrentYear_Returns_Success()
        {
            // Arrange
            var currentYear = DateTime.UtcNow.Year;
            var context = new ValidationContext("Test");

            // Act
            var result = _sut.GetValidationResult(currentYear, context);

            // Assert.
            result.Should().BeNull();
        }

        [Test]
        public void Given_PastYear_Returns_Success()
        {
            // Arrange
            var currentYear = DateTime.UtcNow.Year;
            var context = new ValidationContext("Test");

            // Act
            var result = _sut.GetValidationResult(currentYear - 1, context);

            // Assert.
            result.Should().BeNull();
        }
    }
}
