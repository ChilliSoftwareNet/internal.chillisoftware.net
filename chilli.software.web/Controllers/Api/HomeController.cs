using Abp.AspNetCore.Mvc.Controllers;
using chilli.software.web.Domain.Home.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace chilli.software.web.Controllers.Api
{
    [Route("api/home")]
    public class HomeController : AbpController
    {
        private readonly IHomeService _homeService;

        public HomeController(IHomeService homeService)
        {
            _homeService = homeService;
        }

        [HttpPost("SendEmail")]
        public async Task<JsonResult> SendEmail([FromBody] SendEmailRequestModel request)
        {
            return Json(await _homeService.SendEmail(request));
        }
    }
}