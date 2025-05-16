using System.Numerics;

namespace FitnessCheck.Data.Entities;

public abstract class DisciplineAttempt<T> where T : INumber<T>
{
    public Guid Id { get; set; }
    public byte AttemptNumber { get; set; }
    public DateTime MomentUtc { get; set; }
    public uint Points { get; set; }
    public Guid UserId { get; set; }
    public char Gender { get; set; }
    public Guid CohortId { get; set; }
    public Cohort Cohort { get; set; } = null!;

    public abstract void SetResultValue(T value);
}