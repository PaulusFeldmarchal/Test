using System;
using System.Threading.Tasks;
using frontendServer.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace frontendServer.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserService _service;

        public HomeController(IUserService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index() 
        {
            var items = await _service.GetAll();
            return View(items);
        }
    }
}
