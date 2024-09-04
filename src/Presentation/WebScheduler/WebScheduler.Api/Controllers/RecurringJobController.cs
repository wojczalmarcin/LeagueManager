using Hangfire;
using Microsoft.AspNetCore.Mvc;
using WebScheduler.Api.Contracts;
using WebScheduler.Api.Weebhook;

namespace WebScheduler.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RecurringJobController : ControllerBase
    {
        private readonly IWebhookService _webhookService;

        [HttpPost(Name = "Create new recurring job webhook.")]
        public async Task Post(AsyncJobConfiguration recurringJobConfiguration)
        {
            //TODO: validate cron
            RecurringJob.AddOrUpdate(recurringJobConfiguration.JobId, recurringJobConfiguration.QueueName, 
                () => _webhookService.InvokeWebhook(recurringJobConfiguration.Callback), recurringJobConfiguration.CronExpression);
            await Task.CompletedTask;
        }
    }
}
