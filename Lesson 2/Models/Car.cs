namespace Lesson_2.Models;

/// <summary>
/// Represents a car.
/// </summary>
public class Car : Vehicle
{
    #region Properties

    /// <summary>
    /// Gets the number of doors.
    /// </summary>
    public int NumberDoors { get; }

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a car.
    /// </summary>
    /// <param name="brand">The manufacturer of the car.</param>
    /// <param name="model">The car model.</param>
    /// <param name="numberDoors">The number of doors.</param>
    /// <exception cref="ArgumentOutOfRangeException">The number of doors is not positive.</exception>
    public Car(string brand, string model, int numberDoors)
        : base(brand, model)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(numberDoors);
        NumberDoors = numberDoors;
    }

    #endregion

    #region Methods

    /// <inheritdoc />
    public override string ToString()
    {
        return $"{base.ToString()}, Number of Doors: {NumberDoors}";
    }

    #endregion
}
