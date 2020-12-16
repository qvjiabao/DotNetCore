using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using AutoMapper;
using QJB.Server.Controllers;
using QJB.Server.Result;
using QJB.Shared;
using QJB.IServices;
using QJB.Models;
using QJB.LogExtend;

namespace QJB.Server.Controllers
{

    public class HomeController : BaseController
    {

        private readonly IMenuService _menuService;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        private readonly Logger _logger;

        public HomeController(IMapper mapper, IMenuService menuService, IUserService userService, Logger logger)
        {
            _menuService = menuService;
            _mapper = mapper;
            _userService = userService;
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewBag.displayName = UserInfo.DisplayName;

            return View();
        }
        public IActionResult Welcome()
        {
            return View();
        }

        public IActionResult ChangePwd()
        {
            return View();
        }

        [HttpGet]
        public IEnumerable<MenuVModel> GetAllMenu()
        {
            var roleCode = UserInfo.RoleCode;

            var menuList = _menuService.GetAllMenu(roleCode);

            var list = _mapper.Map<IEnumerable<MenuModel>, IEnumerable<MenuVModel>>(menuList);

            return list;
        }

        public JsonHttpActionResult SavePwd(string old_password, string new_password, string again_password)
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

        [HttpGet]
        public List<Dictionary<string, object>> GetMenuTree(string roleCode)
        {
            return _menuService.GetRoleMenu(roleCode);
        }
    }
}
