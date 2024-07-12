using eRecruitment.Application.Common.Interfaces;
using eRecruitment.Application.Common.Mappings;
using eRecruitment.Application.Common.Models;

namespace eRecruitment.Application.Jobs.Queries.GetJobsWithPagination;
public record GetJobsWithPaginationQuery : IRequest<PaginatedList<JobBriefDto>>
{
    public string? SearchText { get; set; }
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}

public class GetJobsWithPaginationQueryHandler : IRequestHandler<GetJobsWithPaginationQuery, PaginatedList<JobBriefDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetJobsWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<JobBriefDto>> Handle(GetJobsWithPaginationQuery request, CancellationToken cancellationToken)
    {
        if(string.IsNullOrEmpty(request.SearchText))
        {
            return await _context.Jobs
            .OrderBy(x => x.Title)
            .ProjectTo<JobBriefDto>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
        }
        else
        {
            return await _context.Jobs.Where(j => EF.Functions.Like(j.Title, "%"+ request.SearchText + "%") 
            || EF.Functions.Like(j.JobDescriptions, "%" + request.SearchText + "%")
            || EF.Functions.Like(j.Employer, "%" + request.SearchText + "%")
            || EF.Functions.Like(j.Education, "%" + request.SearchText + "%")
            || EF.Functions.Like(j.KeySkills, "%" + request.SearchText + "%"))
            .OrderBy(x => x.Title)
            .ProjectTo<JobBriefDto>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
        }
        
    }
}
