using System.ComponentModel.DataAnnotations;

namespace FitnessCheck.Data.DTO.Request;

public class OneLegStandAttemptCreationRequestDTO
{
    /// <summary>
    /// The result of the one leg stand test attempt in seconds.
    /// </summary>
    [Range(0, 120, ErrorMessage = "Result in seconds must be in range 0 - 120.")]
    [Required(ErrorMessage = "The result in seconds must be provided.")]
    public required uint ResultInSeconds { get; set; }

    /// <summary>
    /// The foot which was used in this attempt.
    /// </summary>
    [Required(ErrorMessage = "The foot (left/right) which was used for the attempt must be provided.")]
    public required EFoot Foot { get; set; }
}
