using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Jabo.Core.Result;
using Jabo.Core.ViewModels;
using Jabo.IServices;
using Jabo.Tools;
using Microsoft.AspNetCore.Mvc;

namespace Jabo.Core.Controllers
{
    public class IndexController : BaseController
    {

        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public IndexController(IMapper mapper, IUserService userService)
        {
            _mapper = mapper;
            _userService = userService;
        }

        public IActionResult Loginout()
        {
            HttpContext.Session.Clear();

            return new RedirectResult("/Other/LoginInvalid");
        }

        public IActionResult Login()
        {
            return View();
        }

        public JsonHttpActionResult VerifyLogin(string username, string password)
        {
            var j = new JsonHttpActionResult();

            var user = _userService.GetUserByUserNameAndPwd(username, password);

            var success = user != null;

            if (success)
            {
                var vModel = _mapper.Map<UserVModel>(user);

                HttpContext.Session.Set("userInfo", ProtoBufHelper.Serialize(vModel));
            }

            j.SetData(success);

            return success ? j.SucceedMessage() : j.ErrorMessage();
        }
    }
}