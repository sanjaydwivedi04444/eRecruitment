using eRecruitment.Domain.Events;
using Microsoft.Extensions.Logging;

namespace eRecruitment.Application.Jobs.EventHandlers;
public class JobCreatedEventHandler : INotificationHandler<JobCreatedEvent>
{
    private readonly ILogger<JobCreatedEventHandler> _logger;

    public JobCreatedEventHandler(ILogger<JobCreatedEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(JobCreatedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("eRecruitment Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}
