using eRecruitment.Application.Common.Interfaces;
using eRecruitment.Application.Common.Mappings;
using eRecruitment.Application.Common.Models;

namespace eRecruitment.Application.Companies.Queries.GetJobsWithPagination;
public record GetCompaniesWithPaginationQuery : IRequest<PaginatedList<CompanyBriefDto>>
{
    public string? SearchText { get; set; }
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}

public class GetCompaniesWithPaginationQueryHandler : IRequestHandler<GetCompaniesWithPaginationQuery, PaginatedList<CompanyBriefDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetCompaniesWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<CompanyBriefDto>> Handle(GetCompaniesWithPaginationQuery request, CancellationToken cancellationToken)
    {
        if(string.IsNullOrEmpty(request.SearchText))
        {
            return await _context.Companies
            .OrderBy(x => x.CompanyTitle)
            .ProjectTo<CompanyBriefDto>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
        }
        else
        {
            return await _context.Companies.Where(j => EF.Functions.Like(j.CompanyTitle, "%"+ request.SearchText + "%") 
            || EF.Functions.Like(j.CompanyDescriptions, "%" + request.SearchText + "%")
            || EF.Functions.Like(j.CompanyType, "%" + request.SearchText + "%")
            || EF.Functions.Like(j.PostalCode, "%" + request.SearchText + "%")
            || EF.Functions.Like(j.OwnerName, "%" + request.SearchText + "%"))
            .OrderBy(x => x.CompanyTitle)
            .ProjectTo<CompanyBriefDto>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
        }
        
    }
}
