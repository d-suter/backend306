namespace FitnessCheck.Data.Entities;

public class TwelveMinutesRunAttempt : DisciplineAttempt<float>
{
    public float ResultInRounds { get; set; }

    public override void SetResultValue(float value)
    {
        ResultInRounds = value;
    }
}
