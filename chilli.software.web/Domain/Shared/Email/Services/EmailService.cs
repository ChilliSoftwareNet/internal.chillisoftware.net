using System.Threading.Tasks;
using chilli.software.web.Domain.Shared.Email.Models;
using Microsoft.Extensions.Options;
using RestSharp;

namespace chilli.software.web.Domain.Shared.Email.Services
{
    public class EmailService : IEmailService
    {
        private readonly IOptions<SendgridConfiguration> _sendgridConfiguration;
        public EmailService(IOptions<SendgridConfiguration> sendgridConfiguration)
        {
            _sendgridConfiguration = sendgridConfiguration;
        }

        public async Task<bool> SendEmail(SendEmailModel model)
        {
            var client = new RestClient(_sendgridConfiguration.Value.Url);
            var request = new RestRequest("chillsoftware.net/messages", Method.POST);

            request.AddParameter("from", model.From);
            model.To.ForEach(m => request.AddParameter("to", m));
            request.AddParameter("subject", model.Subject);
            request.AddParameter("text", model.Text);

            return await ExecuteAsync<dynamic>(client, request);
        }

        private async Task<T> ExecuteAsync<T>(RestClient client, RestRequest request) where T : new()
        {
            var result = new TaskCompletionSource<dynamic>();

            client.ExecuteAsync<T>(request, c =>
            {
                if (c.ErrorException != null)
                {
                    result.SetException(new SendEmailException("Exception during async send", c.ErrorException));
                }
                else
                {
                    result.SetResult(c.Data);
                }
            });

            return await result.Task;
        }
    }
}