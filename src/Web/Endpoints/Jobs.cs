using eRecruitment.Application.Common.Models;
using eRecruitment.Application.Jobs.Commands.CreateJob;
using eRecruitment.Application.Jobs.Commands.DeleteJob;
using eRecruitment.Application.Jobs.Commands.UpdateJob;
using eRecruitment.Application.Jobs.Commands.UpdateJobDetail;
using eRecruitment.Application.Jobs.Queries.GetJobsWithPagination;

namespace eRecruitment.Web.Endpoints;
public class Jobs : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .RequireAuthorization()
            .MapGet(GetJobsWithPagination)
            .MapPost(CreateJob)
            .MapPut(UpdateJob, "{id}")
            .MapPut(UpdateJobDetail, "UpdateDetail/{id}")
            .MapDelete(DeleteJob, "{id}");
    }

    public Task<PaginatedList<JobBriefDto>> GetJobsWithPagination(ISender sender, [AsParameters] GetJobsWithPaginationQuery query)
    {
        return sender.Send(query);
    }

    public Task<int> CreateJob(ISender sender, CreateJobCommand command)
    {
        return sender.Send(command);
    }

    public async Task<IResult> UpdateJob(ISender sender, int id, UpdateJobCommand command)
    {
        if (id != command.Id) return Results.BadRequest();
        await sender.Send(command);
        return Results.NoContent();
    }

    public async Task<IResult> UpdateJobDetail(ISender sender, int id, UpdateJobDetailCommand command)
    {
        if (id != command.Id) return Results.BadRequest();
        await sender.Send(command);
        return Results.NoContent();
    }

    public async Task<IResult> DeleteJob(ISender sender, int id)
    {
        await sender.Send(new DeleteJobCommand(id));
        return Results.NoContent();
    }
}
