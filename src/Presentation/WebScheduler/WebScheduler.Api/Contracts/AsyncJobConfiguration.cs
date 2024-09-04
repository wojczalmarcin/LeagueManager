namespace WebScheduler.Api.Contracts;

public class AsyncJobConfiguration
{
    public string CronExpression { get; set; }

    public string JobId { get; set; }

    public string? QueueName { get; set; }

    public AsyncCallback Callback { get; set; }
}
