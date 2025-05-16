namespace FitnessCheck.Data.DTO.Response;
public class CoreStrengthAttemptResponseDTO : DisciplineAttemptResponseDTO
{
    public uint ResultInSeconds { get; set; }
}

public class AttemptsResponseDTO<T> where T : DisciplineAttemptResponseDTO
{
    public uint Points { get; set; }
    public Guid?[] BestAttemptIds { get; set; } = [];
    public uint RemainingAttempts { get; set; }
    public IEnumerable<T> Attempts { get; set; } = [];
}