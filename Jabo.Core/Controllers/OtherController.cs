﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Jabo.Core.Controllers
{
    public class OtherController : BaseController
    {
        public IActionResult Error404()
        {
            return View();
        }
        public IActionResult LoginInvalid()
        {
            return View();
        }
    }
}