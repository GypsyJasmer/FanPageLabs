﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TheRockFanPage.Controllers
{
    public class MediaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Resources()
        {
            return View();
        }

        public IActionResult Social()
        {
            return View();
        }
    }
}
