namespace Lesson_2.Models;

/// <summary>
/// Represents a vehicle with a brand and model.
/// </summary>
public class Vehicle
{
    #region Properties

    /// <summary>
    /// Gets the vehicle's manufacturer.
    /// </summary>
    public string Brand { get; }

    /// <summary>
    /// Gets the vehicle's model.
    /// </summary>
    public string Model { get; }

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a vehicle.
    /// </summary>
    /// <param name="brand">The manufacturer of the vehicle.</param>
    /// <param name="model">The vehicle model.</param>
    /// <exception cref="ArgumentException">A name is null, empty, or whitespace.</exception>
    public Vehicle(string brand, string model)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(brand);
        ArgumentException.ThrowIfNullOrWhiteSpace(model);

        Brand = brand;
        Model = model;
    }

    #endregion

    #region Methods

    /// <summary>
    /// Writes this vehicle's details to the console.
    /// </summary>
    public void ShowInfo()
    {
        Console.WriteLine(ToString());
    }

    /// <summary>
    /// Returns this vehicle's details.
    /// </summary>
    /// <returns>The vehicle's brand and model.</returns>
    public override string ToString()
    {
        return $"Vehicle Brand: {Brand}, Model: {Model}";
    }

    #endregion
}
