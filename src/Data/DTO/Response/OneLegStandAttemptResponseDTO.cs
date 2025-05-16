namespace FitnessCheck.Data.DTO.Response;

public class OneLegStandAttemptResponseDTO : DisciplineAttemptResponseDTO
{
    public uint ResultInSeconds { get; set; }
    public EFoot Foot { get; set; }
}
