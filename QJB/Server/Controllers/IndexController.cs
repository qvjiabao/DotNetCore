using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using QJB.IServices;
using QJB.Server.Core;
using QJB.Server.Core;

namespace QJB.Server.Controllers
{
    public class IndexController : ControllerBase
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

        //public IActionResult Login()
        //{
        //    return View();
        //}

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