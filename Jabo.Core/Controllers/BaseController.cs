using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Jabo.Core.ViewModels;
using Jabo.Tools;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Jabo.Core.Controllers
{
    public class BaseController : Controller
    {

        public BaseController()
        {
        }

        protected UserVModel UserInfo
        {
            get
            {
                return new UserVModel()
                {
                    DisplayName = User.Claims.FirstOrDefault(s => s.Type == "DisplayName").Value,
                    UserName = User.Claims.FirstOrDefault(s => s.Type == ClaimTypes.Name).Value,
                    RoleCode = User.Claims.FirstOrDefault(s => s.Type == ClaimTypes.Role).Value
                };
            }
        }
    }
}