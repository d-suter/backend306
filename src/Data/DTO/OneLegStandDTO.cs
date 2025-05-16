using System.ComponentModel.DataAnnotations;

namespace FitnessCheckModels
{
    /// <summary>
    /// Represents a data transfer object for one leg stand data.
    /// </summary>
    public class OneLegStandDTO
    {
        /// <summary>
        /// Gets or sets the result in seconds.
        /// </summary>
        [Range(0, int.MaxValue, ErrorMessage = "Result in seconds must be non-negative.")]
        public required int ResultInSeconds { get; set; }

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
