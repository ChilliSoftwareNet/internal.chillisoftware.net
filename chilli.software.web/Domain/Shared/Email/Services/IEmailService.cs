using System.Threading.Tasks;
using Abp.Application.Services;
using chilli.software.web.Domain.Shared.Email.Models;

namespace chilli.software.web.Domain.Shared.Email.Services
{
    public interface IEmailService: IApplicationService
    {
        Task<bool> SendEmail(SendEmailModel model);
    }
}