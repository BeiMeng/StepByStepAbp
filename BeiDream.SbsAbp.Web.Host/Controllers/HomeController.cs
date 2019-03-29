﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BeiDream.SbsAbp.Web.Host.Controllers
{
    public class HomeController : ControllerBaseController
    {
        public IActionResult Index()
        {
            return Redirect("/swagger");
        }
    }
}