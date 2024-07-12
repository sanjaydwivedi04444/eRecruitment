using eRecruitment.Domain.Entities;

namespace eRecruitment.Application.Jobs.Queries.GetJobsWithPagination;
public class JobBriefDto
{
    public int Id { get; init; }
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

    public bool Done { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Job, JobBriefDto>();
        }
    }
}
