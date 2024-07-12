using eRecruitment.Application.Common.Models;
using eRecruitment.Application.Companies.Queries.GetJobsWithPagination;

namespace eRecruitment.Web.Endpoints;
public class Companies : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .RequireAuthorization()
            .MapGet(GetCompaniesWithPagination);
    }

    public Task<PaginatedList<CompanyBriefDto>> GetCompaniesWithPagination(ISender sender, [AsParameters] GetCompaniesWithPaginationQuery query)
    {
        return sender.Send(query);
    }

    //public Task<int> CreateJob(ISender sender, CreateJobCommand command)
    //{
    //    return sender.Send(command);
    //}

    //public async Task<IResult> UpdateJob(ISender sender, int id, UpdateJobCommand command)
    //{
    //    if (id != command.Id) return Results.BadRequest();
    //    await sender.Send(command);
    //    return Results.NoContent();
    //}

    //public async Task<IResult> UpdateJobDetail(ISender sender, int id, UpdateJobDetailCommand command)
    //{
    //    if (id != command.Id) return Results.BadRequest();
    //    await sender.Send(command);
    //    return Results.NoContent();
    //}

    //public async Task<IResult> DeleteJob(ISender sender, int id)
    //{
    //    await sender.Send(new DeleteJobCommand(id));
    //    return Results.NoContent();
    //}
}
