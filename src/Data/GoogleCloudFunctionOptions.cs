namespace FitnessCheck.Data;

public class GoogleCloudFunctionOptions
{
    public const string ConfigurationPath = "GoogleCloudFunctions";

    public string GetGenderUrl { get; set; } = null!;
    public string GetCohortUrl { get; set; } = null!;
}
