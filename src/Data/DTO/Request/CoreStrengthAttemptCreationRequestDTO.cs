using System.ComponentModel.DataAnnotations;

namespace FitnessCheck.Data.DTO.Request;

public class CoreStrengthAttemptCreationRequestDTO
{
    /// <summary>
    /// The result of the core strength test attempt in seconds.
    /// </summary>
    [Range(0, 360, ErrorMessage = "Result in seconds must be in range 0 - 360.")]
    [Required(ErrorMessage = "The result in seconds must be provided.")]
    public required uint ResultInSeconds { get; set; }
}