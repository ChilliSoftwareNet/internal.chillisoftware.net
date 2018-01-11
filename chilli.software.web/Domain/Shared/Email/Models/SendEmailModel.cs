using System.Collections.Generic;

namespace chilli.software.web.Domain.Shared.Email.Models
{
    public class SendEmailModel
    {
        public string From { get; set; }
        public List<string> To { get; set; }
        public string Subject { get; set; }
        public string Text { get; set; }
    }
}