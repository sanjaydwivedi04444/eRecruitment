using eRecruitment.Application.Common.Interfaces;
using eRecruitment.Domain.Events;

namespace eRecruitment.Application.Jobs.Commands.DeleteJob;
public record DeleteJobCommand(int Id) : IRequest;

public class DeleteJobCommandHandler : IRequestHandler<DeleteJobCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteJobCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(DeleteJobCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Jobs
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        _context.Jobs.Remove(entity);

        entity.AddDomainEvent(new JobDeletedEvent(entity));

        await _context.SaveChangesAsync(cancellationToken);
    }

}
