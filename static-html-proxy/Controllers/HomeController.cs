using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace static_html_proxy.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var _url = @"https://raw.githubusercontent.com/txstudio/blogspot-image/master/style.css";
            var _content = string.Empty;

            HttpClient _client = new HttpClient();
            var _response = _client.GetAsync(_url).Result;

            if(_response.IsSuccessStatusCode == true)
            {
                _content = _response.Content.ReadAsStringAsync().Result;
            }

            return Content(_content, "text/css; charset=utf-8");
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
