namespace Lesson_2.Models;

/// <summary>
/// Base type for people represented in this lesson.
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

    private DateOnly? birthDate;

    #endregion

    #region Methods

    /// <summary>
    /// Stores a valid date of birth.
    /// </summary>
    /// <param name="birthDate">The person's date of birth.</param>
    /// <exception cref="ArgumentOutOfRangeException">The date is in the future.</exception>
    public void SetBirthDate(DateOnly birthDate)
    {
        if (birthDate > DateOnly.FromDateTime(DateTime.Today))
        {
            throw new ArgumentOutOfRangeException(
                nameof(birthDate),
                "Birth date cannot be in the future.");
        }

        this.birthDate = birthDate;
    }

    /// <summary>
    /// Gets the date of birth, if one has been set.
    /// </summary>
    /// <returns>The person's date of birth.</returns>
    /// <exception cref="InvalidOperationException">No date of birth has been set.</exception>
    public DateOnly GetBirthDate()
    {
        return birthDate ?? throw new InvalidOperationException("Birth date has not been set.");
    }

    /// <summary>
    /// Calculates the person's age in whole years.
    /// </summary>
    /// <returns>The person's age.</returns>
    /// <exception cref="InvalidOperationException">No date of birth has been set.</exception>
    public int CalculateAge()
    {
        DateOnly dateOfBirth = GetBirthDate();
        DateOnly today = DateOnly.FromDateTime(DateTime.Today);
        int age = today.Year - dateOfBirth.Year;
        if (dateOfBirth > today.AddYears(-age))
        {
            age--;
        }

        return age;
    }

    /// <summary>
    /// Returns a human-readable description of this entity.
    /// </summary>
    /// <returns>A description of this entity.</returns>
    public abstract string GetDescription();

    #endregion
}