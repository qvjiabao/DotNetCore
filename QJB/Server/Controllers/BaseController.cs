using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QJB.Shared;

namespace QJB.Server.Controllers
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