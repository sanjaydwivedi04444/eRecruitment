namespace eRecruitment.Domain.Events;

public class JobDeletedEvent : BaseEvent
{
    public JobDeletedEvent(Job item)
    {
        Item = item;
    }

    public Job Item { get; }
}
