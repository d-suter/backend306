using System.ComponentModel.DataAnnotations;

namespace FitnessCheck.Data.DTO.Request;

public class StandingLongJumpAttemptCreationRequestDTO
{
    /// <summary>
    /// The distance for the standing long jump attempt in centimeters.
    /// </summary>
    [Range(80, 320, ErrorMessage = "Result in centimeters must be in range 80 - 320.")]
    [Required(ErrorMessage = "The result in centimeters must be provided.")]
    public required uint ResultInCentimeters { get; set; }
}
