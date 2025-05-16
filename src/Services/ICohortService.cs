using FitnessCheck.Data.Entities;

namespace FitnessCheck.Services;

public interface ICohortService
{
    public Task<Cohort?> GetCohortAsync(string username);
}