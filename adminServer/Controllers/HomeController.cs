using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using adminServer.Domain.Interfaces;
using adminServer.Models;
using adminServer.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace adminServer.Controllers
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
            ViewData["Users"] = await _service.GetAll();
            return View();
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _service.Delete(id);
            return RedirectPermanent("~/Home/Index"); ;
        }
    }
}
