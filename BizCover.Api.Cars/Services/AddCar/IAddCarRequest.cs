namespace BizCover.Api.Cars.Services.AddCar
{
    public interface IAddCarRequest
    {
        string Color { get;  }

        string CountryManufactured { get;  }

        string Make { get;  }

        string Model { get; }

        decimal Price { get; }

        int Year { get;  }
    }
}