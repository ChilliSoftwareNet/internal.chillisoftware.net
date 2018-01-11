using Abp.Application.Services;
using System.Threading.Tasks;

namespace chilli.software.web.Domain.Home.Services
{
    public interface IHomeService: IApplicationService 
    {
        Task<bool> SendEmail(SendEmailRequestModel emailModel);
    }
}