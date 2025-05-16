using System.ComponentModel.DataAnnotations;

namespace FitnessCheckModels
{
    /// <summary>
    /// Represents a data transfer object for twelve minutes run data.
    /// </summary>
    public class TwelveMinutesRunDTO
    {
        /// <summary>
        /// Gets or sets the result in rounds.
        /// </summary>
        [Range(0, float.MaxValue, ErrorMessage = "Result in rounds must be non-negative.")]
        public required float ResultInRounds { get; set; }

        /// <summary>
        /// Gets or sets the points.
        /// </summary>
        [Range(0, int.MaxValue, ErrorMessage = "Points must be non-negative.")]
        public int Points { get; set; }

        /// <summary>
        /// Gets or sets the class ID.
        /// </summary>
        [Range(100000, 999999, ErrorMessage = "Class ID must be a 6-digit integer.")]
        public required int ClassId { get; set; }
    }
}
