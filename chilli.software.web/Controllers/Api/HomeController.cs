﻿using Abp.AspNetCore.Mvc.Controllers;
using chilli.software.web.Domain.Home.Services;
using Microsoft.AspNetCore.Mvc;

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
        public JsonResult SendEmail([FromBody] SendEmailRequestModel request)
        {
            return Json(new {});
        }
    }
}