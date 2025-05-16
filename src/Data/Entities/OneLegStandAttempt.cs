namespace FitnessCheck.Data.Entities;

public class OneLegStandAttempt : DisciplineAttempt<uint>
{
    public EFoot Foot { get; set; }
    public uint ResultInSeconds { get; set; }

    public override void SetResultValue(uint value)
    {
        ResultInSeconds = value;
    }
}
