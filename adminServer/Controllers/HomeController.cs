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
            return View(await _service.GetAll());
        }

        [HttpGet]
        public async Task<IActionResult> GetUser(int id)
        {
            UserModel element = await _service.Get(id);
            return Json(element);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.Delete(id);
            return Json("Element deleted!");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UserModel model)
        {
            await _service.Update(model);
            return Json("Element changed!");
        }

        [HttpPost]
        public async Task<IActionResult> Add(UserModel model)
        {
            await _service.Add(model);
            return Json("Element Added!");
        }
    }
}
