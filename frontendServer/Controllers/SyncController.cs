using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using frontendServer.Models;
using frontendServer.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace frontendServer.Controllers
{
    public class SyncController : Controller
    {
        private readonly IUserService _service;

        public SyncController(IUserService service)
        {
            _service = service;
        }
        // GET: Sync
        [HttpPost]
        public async Task<ActionResult> IndexAsync()
        {

            var request = (HttpWebRequest)WebRequest.Create("http://localhost:9191/Sync");

            var response = (HttpWebResponse)await request.GetResponseAsync();

            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();


            return Redirect("~/Home");
        }

        [HttpPost]
        public async Task<string> PostData(string data)
        {
            IEnumerable<UserModel> items = JsonConvert.DeserializeObject<List<UserModel>>(data);

            await _service.DeleteAll();
            
            foreach(var item in items)
            {
                await _service.Add(item);
            }

            return "Yeees! ";
        }
    }
}