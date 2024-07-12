using eRecruitment.Domain.Entities;

namespace eRecruitment.Application.Companies.Queries.GetJobsWithPagination;
public class CompanyBriefDto
{
    public string? CompanyTitle { get; set; }
    public string? CompanyDescriptions { get; set; }
    public string? CompanyType { get; set; }
    public int NoofEmployee { get; set; }
    public string? Address { get; set; }
    public string? OwnerName { get; set; }
    public string? OwnerEmail { get; set; }
    public int CompanyTelephone { get; set; }
    public int City { get; set; }
    public int Region { get; set; }
    public string? PostalCode { get; set; }
    public int Country { get; set; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Company, CompanyBriefDto>();
        }
    }
}
