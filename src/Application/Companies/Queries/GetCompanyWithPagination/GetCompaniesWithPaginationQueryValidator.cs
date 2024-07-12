using eRecruitment.Application.Companies.Queries.GetJobsWithPagination;

namespace eRecruitment.Application.Companies.Queries.GetCompaniesWithPagination;

public class GetCompaniesWithPaginationQueryValidator : AbstractValidator<GetCompaniesWithPaginationQuery>
{
    public GetCompaniesWithPaginationQueryValidator()
    {

        RuleFor(x => x.PageNumber)
            .GreaterThanOrEqualTo(1).WithMessage("PageNumber at least greater than or equal to 1.");

        RuleFor(x => x.PageSize)
            .GreaterThanOrEqualTo(1).WithMessage("PageSize at least greater than or equal to 1.");
    }
}
