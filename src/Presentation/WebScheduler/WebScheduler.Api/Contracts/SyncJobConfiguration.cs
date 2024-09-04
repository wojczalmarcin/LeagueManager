namespace WebScheduler.Api.Contracts;
public class SyncJobConfiguration
{
    public string CronExpression { get; set; }

    public string JobId { get; set; }

    public string? QueueName { get; set; }

    public IEnumerable<SyncCallback> Callbacks { get; set; }
}

