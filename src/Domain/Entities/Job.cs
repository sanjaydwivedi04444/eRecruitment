namespace eRecruitment.Domain.Entities;

public class Job : BaseAuditableEntity
{
    public string? Title { get; set; }
    public string? JobDescriptions { get; set; }
    public string? Employer { get; set; }
    public int Salary { get; set; }
    public string? Experience { get; set; }
    public string? Location { get; set; }
    public string? Role { get; set; }
    public string? EmploymentType { get; set; }
    public string? Education { get; set; }
    public string? IndustryType { get; set; }
    public string? KeySkills { get; set; }
    public int Openings { get; set; }

    public string? WorkMode { get; set; }

    private bool _done;
    public bool Done
    {
        get => _done;
        set
        {
            if (value && !_done)
            {
                AddDomainEvent(new JobCompletedEvent(this));
            }

            _done = value;
        }
    }
}
