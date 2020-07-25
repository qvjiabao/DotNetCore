using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Jabo.Core.Result;
using Jabo.Core.ViewModels;
using Jabo.IServices;
using Jabo.Tools;
using Microsoft.AspNetCore.Authentication;
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
            return new RedirectResult("/Other/LoginInvalid");
        }

        public IActionResult Login()
        {
            return View();
        }

        public JsonHttpActionResult ChangePwd(string old_password, string new_password, string again_password)
        {
            var j = new JsonHttpActionResult();

            if (new_password != again_password)
            {
                return j.ErrorMessage("两次密码输入不一致");
            }

            var user = _userService.GetUserByUserNameAndPwd(UserInfo.UserName, old_password);

            if (user == null)
            {
                return j.ErrorMessage("旧密码错误");
            }

            user.PassWord = new_password;

            var success = _userService.SaveUser(user, true);

            j.SetData(success);

            return success ? j.SucceedMessage() : j.ErrorMessage();
        }


        public JsonHttpActionResult VerifyLogin(string username, string password)
        {
            var j = new JsonHttpActionResult();

            var user = _userService.GetUserByUserNameAndPwd(username, password);

            var success = user != null;

            if (success)
            {
                var userClaims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.Role, user.RoleCode),
                    new Claim("DisplayName",user.DisplayName)
                };

                var grandmaIdentity = new ClaimsIdentity(userClaims, "User Identity");

                var userPrincipal = new ClaimsPrincipal(new[] { grandmaIdentity });

                HttpContext.SignInAsync(userPrincipal);

            }

            j.SetData(success);

            return success ? j.SucceedMessage() : j.ErrorMessage();
        }
    }
}