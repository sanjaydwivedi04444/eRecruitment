namespace eRecruitment.Domain.Events;

public class JobCreatedEvent : BaseEvent
{
    public JobCreatedEvent(Job item)
    {
        Item = item;
    }

    public Job Item { get; }
}
