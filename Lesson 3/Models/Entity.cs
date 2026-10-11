namespace Lesson_3.Models;

/// <summary>
/// Base type for entities with an identity and date of birth.
/// </summary>
public abstract class Entity
{
    #region Properties

    /// <summary>
    /// Gets or sets the entity's identifier.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the entity's name.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    private DateOnly? dateOfBirth;

    #endregion

    #region Methods

    /// <summary>
    /// Writes this entity's information to the console.
    /// </summary>
    public abstract void DisplayInfo();

    /// <summary>
    /// Stores a valid date of birth.
    /// </summary>
    /// <param name="date">The date of birth.</param>
    /// <exception cref="ArgumentOutOfRangeException">The date is in the future.</exception>
    public void SetDateOfBirth(DateOnly date)
    {
        if (date > DateOnly.FromDateTime(DateTime.Today))
        {
            throw new ArgumentOutOfRangeException(nameof(date), "Date of birth cannot be in the future.");
        }

        dateOfBirth = date;
    }

    /// <summary>
    /// Gets the date of birth, if one has been set.
    /// </summary>
    /// <returns>The date of birth.</returns>
    /// <exception cref="InvalidOperationException">No date of birth has been set.</exception>
    public DateOnly GetDateOfBirth()
    {
        return dateOfBirth ?? throw new InvalidOperationException("Date of birth is not set.");
    }

    /// <summary>
    /// Calculates this entity's age in whole years.
    /// </summary>
    /// <returns>The age in years.</returns>
    /// <exception cref="InvalidOperationException">No date of birth has been set.</exception>
    public int GetAge()
    {
        DateOnly birthDate = GetDateOfBirth();
        DateOnly today = DateOnly.FromDateTime(DateTime.Today);
        int age = today.Year - birthDate.Year;
        if (birthDate > today.AddYears(-age))
        {
            age--;
        }

        return age;
    }

    #endregion
}