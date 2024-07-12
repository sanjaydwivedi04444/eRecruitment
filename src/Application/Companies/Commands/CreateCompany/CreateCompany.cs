using eRecruitment.Application.Common.Interfaces;
using eRecruitment.Domain.Entities;
using eRecruitment.Domain.Events;

namespace eRecruitment.Application.Jobs.Commands.CreateJob;
public record CreateJobCommand : IRequest<int>
{
    public string? Title { get; init; }
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
}

public class CreateJobCommandHandler : IRequestHandler<CreateJobCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateJobCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateJobCommand request, CancellationToken cancellationToken)
    {
        var entity = new Job
        {
            Title = request.Title,
            JobDescriptions=request.JobDescriptions,
            Employer = request.Employer,
            Experience = request.Experience,
            Location = request.Location,
            Role = request.Role,
            EmploymentType = request.EmploymentType,
            Education = request.Education,
            IndustryType = request.IndustryType,
            KeySkills = request.KeySkills,
            Openings = request.Openings,
            WorkMode = request.WorkMode,
            Done = false
        };

        entity.AddDomainEvent(new JobCreatedEvent(entity));

        _context.Jobs.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
