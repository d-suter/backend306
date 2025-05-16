namespace FitnessCheck.Data.Entities;

public class MedicineBallPushAttempt : DisciplineAttempt<uint>
{
    public uint ResultInCentimeters { get; set; }

    public override void SetResultValue(uint value)
    {
        ResultInCentimeters = value;
    }
}
