namespace FitnessCheck.Services;

/// <summary>
/// Interface for providing gender-related services.
/// </summary>
public interface IGenderService
{
    /// <summary>
    /// Asynchronously retrieves the gender of a user by their username.
    /// </summary>
    /// <param name="username">The username of the user.</param>
    /// <returns>A Task that represents the asynchronous operation, containing the user's gender as a char.</returns>
    Task<char> GetGenderAsync(string username);
}