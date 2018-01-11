using System.Collections.Generic;
using System.Threading.Tasks;
using chilli.software.web.Domain.Shared.Email.Services;

namespace chilli.software.web.Domain.Home.Services
{
    public class HomeService : IHomeService
    {
        private readonly IEmailService _emailService;

        public HomeService(IEmailService emailService)
        {
            _emailService = emailService;
        }

        public async Task<bool> SendEmail(SendEmailRequestModel emailModel)
        {
            return await _emailService.SendEmail(new Shared.Email.Models.SendEmailModel
            {
                From = "contact@chillisoftware.net",
                To = new List<string> { "jmalczak@gmail.com" },
                Subject = "Contact from chillisoftware.net",
                Text = $"Name: {emailModel.Name}<br/>Email: {emailModel.Email}<br/>Phone: {emailModel.Phone}<br/>Message: {emailModel.Message}<br/>"
            });
        }
    }
}
