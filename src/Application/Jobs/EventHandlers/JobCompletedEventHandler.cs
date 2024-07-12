using eRecruitment.Domain.Events;
using Microsoft.Extensions.Logging;

namespace eRecruitment.Application.Jobs.EventHandlers;
public class JobCompletedEventHandler : INotificationHandler<JobCompletedEvent>
{
    private readonly ILogger<JobCompletedEventHandler> _logger;

    public JobCompletedEventHandler(ILogger<JobCompletedEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(JobCompletedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("eRecruitment Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}
