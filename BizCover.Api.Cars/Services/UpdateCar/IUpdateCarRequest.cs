namespace BizCover.Api.Cars.Services.UpdateCar
{
    public interface IUpdateCarRequest
    {
        string Colour { get; }

        string CountryManufactured { get; }

        int Id { get; }

        string Make { get; }

        string Model { get; }

        decimal Price { get; }

        int Year { get; }
    }
}