using FitnessCheckModels;

namespace FitnessCheck.Services
{
    /// <summary>
    /// Defines an Interface for calculating points based on a given filter criteria.
    /// </summary>
    public interface IPointsCalculator
    {
        /// <summary>
        /// Calculates the score as a value between 0 to 25 points based on the provided filter criteria.
        /// </summary>
        /// <param name="predicate">The filter criteria for querying the results.</param>
        /// <returns>The calculated Points</returns>

        uint CalculatePoints(Func<ResultsCalculation, bool> filter);
    }
}
