namespace chilli.software.web.Domain.Home.Services
{
    public class HomeService : IHomeService
    {
        private readonly IEmailService _emailService;

        public HomeService(IEmailService emailService)
        {
            _emailService = emailService;
        } 
    }
}