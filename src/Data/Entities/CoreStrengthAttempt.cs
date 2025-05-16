namespace FitnessCheck.Data.Entities;

public class CoreStrengthAttempt : DisciplineAttempt<uint>
{
    public uint ResultInSeconds { get; set; }

    public override void SetResultValue(uint value)
    {
        ResultInSeconds = value;
    }
}
