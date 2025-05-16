using System.ComponentModel.DataAnnotations;

namespace FitnessCheck.Data.DTO.Request;

public class TwelveMinutesRunAttemptCreationRequestDTO
{
    /// <summary>
    /// The count of laps in the twelve minutes run.
    /// </summary>
    [Range(18, 55, ErrorMessage = "Result in rounds must be in range 18 - 55.")]
    [Required(ErrorMessage = "The result in rounds must be provided.")]
    public required float ResultInRounds { get; set; }
}