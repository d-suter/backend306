namespace FitnessCheck.Data.Entities;
public class Cohort
{
    public Guid Id { get; set; }
    public string Profession { get; set; } = null!;
    public bool Baccalaureate { get; set; }
    public byte SchoolYear { get; set; }
    public uint FirstSchoolYear { get; set; }
    public string ClassNameVocationalEducation { get; set; } = null!;
    public string? ClassNameBaccalaureate { get; set; } = null!;
}
