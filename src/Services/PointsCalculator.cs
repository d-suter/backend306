using FitnessCheck.Data;
using FitnessCheckModels;

namespace FitnessCheck.Services
{
    /// <summary>
    /// A service that calculates points based on a given filter criteria.
    /// </summary>
    public class PointsCalculator : IPointsCalculator
    {
        private readonly FitnessCheckDbContext _dbContext;

        public PointsCalculator(FitnessCheckDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Calculates the highest points based on the provided filter criteria.
        /// </summary>
        /// <param name="predicate">The filter criteria for querying the results.</param>
        /// <returns>The highest points from the results that match the filter criteria.</returns>
        /// <exception cref="InvalidOperationException">Thrown when no results are found for the given filter criteria.</exception>
        virtual public uint CalculatePoints(Func<ResultsCalculation, bool> predicate)
        {
            // Query result based on the provided predicate and order by points
            var highestPointsResult = _dbContext.Results
                                        .Where(predicate)
                                        .OrderByDescending(x => x.Points)
                                        .FirstOrDefault() ?? throw new Exception("No points found for the given parameters.");

            return highestPointsResult.Points;
        }
        
    }
}
