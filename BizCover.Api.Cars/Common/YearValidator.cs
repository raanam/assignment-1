using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BizCover.Api.Cars.Common
{
    public class YearValidator : ValidationAttribute
    {
        public const string InvalidValue = "Year should be integer";

        public const string YearCannotBeFuture = "Year cannot be in future";

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            int parsedValue = 0;

            if (!int.TryParse(value?.ToString(), out parsedValue))
            {
                return new ValidationResult(InvalidValue);
            }

            if (parsedValue > DateTime.UtcNow.Year)
            {
                return new ValidationResult(YearCannotBeFuture);
            }

            return ValidationResult.Success;
        }
    }
}