using WebScheduler.Api.Contracts;

namespace WebScheduler.Api.Weebhook
{
    public interface IWebhookService
    {
        Task InvokeWebhook(Contracts.AsyncCallback callback);
    }
}
