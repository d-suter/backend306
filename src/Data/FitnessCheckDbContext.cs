using System.Text.Json;
using FitnessCheck.Data.Entities;
using FitnessCheckModels;
using Microsoft.EntityFrameworkCore;

namespace FitnessCheck.Data;
public class FitnessCheckDbContext : DbContext
{
    public virtual DbSet<CoreStrengthAttempt> CoreStrengthAttempts { get; set; }
    public virtual DbSet<MedicineBallPushAttempt> MedicineBallPushAttempts { get; set; }
    public virtual DbSet<StandingLongJumpAttempt> StandingLongJumpAttempts { get; set; }
    public virtual DbSet<OneLegStandAttempt> OneLegStandAttempts { get; set; }
    public virtual DbSet<ShuttleRunAttempt> ShuttleRunAttempts { get; set; }
    public virtual DbSet<TwelveMinutesRunAttempt> TwelveMinutesRunAttempts { get; set; }
    public virtual DbSet<ResultsCalculation> Results { get; set; }
    public virtual DbSet<Cohort> Cohorts { get; set; }

    public FitnessCheckDbContext() : base()
    {

    }

    public FitnessCheckDbContext(DbContextOptions<FitnessCheckDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Seed data
        SeedResultsCalculation(modelBuilder);
    }

    private void SeedResultsCalculation(ModelBuilder modelBuilder)
    {
        var resultsCalculation = DeserializeJSON<ResultsCalculation>("Data/ResultsCalculationData.json");
        modelBuilder.Entity<ResultsCalculation>().HasData(resultsCalculation);
    }

    private IEnumerable<T> DeserializeJSON<T>(string jsonFileName)
    {
        var json = File.ReadAllText(jsonFileName);
        return JsonSerializer.Deserialize<IEnumerable<T>>(json);
    }
}