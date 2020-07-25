﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Jabo.Core.Controllers
{
    [Authorize]
    public class OtherController : BaseController
    {
        public IActionResult Error404()
        {
            return View();
        }
        public IActionResult LoginInvalid()
        {
            //注销登录
            Task.Run(async () =>
            {
                await HttpContext.SignOutAsync();
            }).Wait();

            return View();
        }
    }
}