using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using adminServer.Domain.Interfaces;
using adminServer.Models;
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


        public IActionResult Index()
        {
            return View();
        }
    }
}
