namespace FitnessCheck.Data.DTO.Response;

public abstract class DisciplineAttemptResponseDTO
{
    public Guid Id { get; set; }
    public byte AttemptNumber { get; set; }
    public DateTime MomentUtc { get; set; }
    public uint Points { get; set; }
    public Guid UserId { get; set; }
    public char Gender { get; set; }
    public Guid CohortId { get; set; }
}
