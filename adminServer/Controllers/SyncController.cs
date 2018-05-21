using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using adminServer.Models;
using adminServer.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
namespace adminServer.Controllers
{
    public class SyncController : Controller
    {
        private readonly IUserService _service;
        private static readonly HttpClient client = new HttpClient();

        public SyncController(IUserService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<ActionResult> Index()
        {
            string result;
            WebRequest request = WebRequest.Create("http://localhost:9292/Sync/PostData");
            request.Method = "POST";
            string data = "data=" + JsonConvert.SerializeObject(await _service.GetAll());
            byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(data);
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = byteArray.Length;

            using (Stream dataStream = request.GetRequestStream())
            {
                dataStream.Write(byteArray, 0, byteArray.Length);
            }
            WebResponse response = await request.GetResponseAsync();
            using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    result = reader.ReadToEnd();
                }
            }
            response.Close();
            return Json(result);
        }
    }
}