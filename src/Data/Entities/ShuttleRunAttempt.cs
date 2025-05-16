namespace FitnessCheck.Data.Entities;

public class ShuttleRunAttempt : DisciplineAttempt<uint>
{
    public uint ResultInMilliseconds { get; set; }

    public override void SetResultValue(uint value)
    {
        ResultInMilliseconds = value;
    }
}
