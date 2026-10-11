namespace Lesson_2.Models;

/// <summary>
/// Represents a motorcycle.
/// </summary>
public class Moto : Vehicle
{
    #region Properties

    /// <summary>
    /// Gets the number of wheels.
    /// </summary>
    public int NumberWheels { get; }

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a motorcycle.
    /// </summary>
    /// <param name="brand">The manufacturer of the motorcycle.</param>
    /// <param name="model">The motorcycle model.</param>
    /// <param name="numberWheels">The number of wheels.</param>
    /// <exception cref="ArgumentOutOfRangeException">The number of wheels is not positive.</exception>
    public Moto(string brand, string model, int numberWheels)
        : base(brand, model)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(numberWheels);
        NumberWheels = numberWheels;
    }

    #endregion

    #region Methods

    /// <summary>
    /// Writes the motorcycle details to the console.
    /// </summary>
    public void Info()
    {
        Console.WriteLine(ToString());
    }

    /// <inheritdoc />
    public override string ToString()
    {
        return $"{base.ToString()}, Number of Wheels: {NumberWheels}";
    }

    #endregion
}
