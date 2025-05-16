using System.Numerics;
using System.Reflection;
using FitnessCheck.Data.Entities;

namespace FitnessCheck.Data;

public class MaxAllowedAttemptsOptions
{
    public const string ConfigurationPath = "FitnessCheck:MaxAllowedAttempts";

    public byte CoreStrength { get; set; }
    public byte MedicineBallPush { get; set; }
    public byte OneLegStand { get; set; }
    public byte ShuttleRun { get; set; }
    public byte StandingLongJump { get; set; }
    public byte TwelveMinutesRun { get; set; }

    public byte GetForDisciplineAttempt<TDiscipline, TResultValue>()
        where TDiscipline : DisciplineAttempt<TResultValue>
        where TResultValue : INumber<TResultValue>
    {
        string propertyName = typeof(TDiscipline).Name;
        propertyName = propertyName[..^"Attempt".Length];
        PropertyInfo? propertyInfo = GetType().GetProperty(propertyName);

        if (propertyInfo is null)
        {
            return 1;
        }

        object? propertyValue = propertyInfo.GetValue(this);

        if (propertyValue is null)
        {
            return 1;
        }

        return (byte)propertyValue;
    }
}