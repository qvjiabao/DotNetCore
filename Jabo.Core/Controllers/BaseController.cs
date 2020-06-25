using System;
using System.Collections.Generic;
using System.Linq;
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
                if (HttpContext.Session.Keys.Contains("userInfo"))
                {
                    var bytes = HttpContext.Session.Get("userInfo");

                    var obj = ProtoBufHelper.DeSerialize<UserVModel>(bytes);

                    return obj;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}