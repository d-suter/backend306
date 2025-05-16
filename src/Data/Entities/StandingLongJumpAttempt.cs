namespace FitnessCheck.Data.Entities;

public class StandingLongJumpAttempt : DisciplineAttempt<uint>
{
    public uint ResultInCentimeters { get; set; }

    public override void SetResultValue(uint value)
    {
        ResultInCentimeters = value;
    }
}
