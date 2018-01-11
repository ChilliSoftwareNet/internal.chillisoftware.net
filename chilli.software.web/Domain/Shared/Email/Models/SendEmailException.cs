using System;

namespace chilli.software.web.Domain.Shared.Email.Models
{
    public class SendEmailException : Exception
    {
        public SendEmailException(string message, Exception innerException) :base(message, innerException)
        {
            
        }
    }
}