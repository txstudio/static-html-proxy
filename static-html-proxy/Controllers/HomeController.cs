﻿using System;
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
            return NotFound();
        }
    }
}
