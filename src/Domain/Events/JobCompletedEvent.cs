namespace eRecruitment.Domain.Events;

public class JobCompletedEvent : BaseEvent
{
    public JobCompletedEvent(Job item)
    {
        Item = item;
    }

    public Job Item { get; }
}
