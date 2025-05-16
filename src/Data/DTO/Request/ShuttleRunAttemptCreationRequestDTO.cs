using System.ComponentModel.DataAnnotations;

namespace FitnessCheck.Data.DTO.Request;

public class ShuttleRunAttemptCreationRequestDTO
{
    /// <summary>
    /// The measured time for the shuttle run attempt in seconds.
    /// A shorter time is better!
    /// </summary>
    [Range(8_000, 14_000, ErrorMessage = "Result in milliseconds must be in range 8'000 - 14'000.")]
    [Required(ErrorMessage = "The result in milliseconds must be provided.")]
    public required uint ResultInMilliseconds { get; set; }
}
