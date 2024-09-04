namespace WebScheduler.Api.Contracts;
public class SyncCallback
{
    public string Address { get; set; }

    public string HttpMethod { get; set; }

    public string Payload { get; set; }

    public int MillisecondsTimeout { get; set; }

    public int Priority { get; set; }
}
