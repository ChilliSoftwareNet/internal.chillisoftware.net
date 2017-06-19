using Abp.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace chilli.software.web.Controllers
{
    public class HomeController : AbpController
    {
        public HomeController()
        {

        }

        public IActionResult Index()
        {
            return View();
        }
    }
}