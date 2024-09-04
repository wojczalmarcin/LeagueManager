using WebScheduler.Api.Contracts;

namespace WebScheduler.Api.Weebhook
{
    public class WebhookService : IWebhookService
    {
        public HttpClient _httpClient { get; set; }

        public WebhookService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task InvokeWebhook(Contracts.AsyncCallback callback)
        {
            await _httpClient.PostAsync(callback.Address, JsonContent.Create(callback.Payload));
        }
    }
}
