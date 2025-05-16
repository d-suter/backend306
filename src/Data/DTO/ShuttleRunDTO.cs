using System.ComponentModel.DataAnnotations;

namespace FitnessCheckModels
{
    /// <summary>
    /// Represents a data transfer object for shuttle run data.
    /// </summary>
    public class ShuttleRunDTO
    {
        /// <summary>
        /// Gets or sets the result in milliseconds.
        /// </summary>
        [Range(0, 100000, ErrorMessage = "Result in milliseconds must be non-negative and not higher than 100s.")]
        public required int ResultInMilliseconds { get; set; }

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
