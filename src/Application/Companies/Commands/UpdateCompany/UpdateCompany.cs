using eRecruitment.Application.Common.Interfaces;

namespace eRecruitment.Application.Jobs.Commands.UpdateJob;
public record UpdateJobCommand : IRequest
{
    public int Id { get; init; }
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

public class UpdateJobCommandHandler : IRequestHandler<UpdateJobCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateJobCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateJobCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Jobs
            .FindAsync(new object[] { request.Id }, cancellationToken);
        Guard.Against.NotFound(request.Id, entity);
        entity.Title = request.Title;
        entity.JobDescriptions = request.JobDescriptions;
        entity.Employer = request.Employer;
        entity.Experience = request.Experience;
        entity.Location = request.Location;
        entity.Role = request.Role;
        entity.EmploymentType = request.EmploymentType;
        entity.Education = request.Education;
        entity.IndustryType = request.IndustryType;
        entity.KeySkills = request.KeySkills;
        entity.Openings = request.Openings;
        entity.WorkMode = request.WorkMode;
        entity.Done = false;

        await _context.SaveChangesAsync(cancellationToken);
    }
}
