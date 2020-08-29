using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Jabo.IServices;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Jabo.Core.ViewModels;
using AutoMapper;
using Jabo.Models;
using Jabo.Tools;
using Jabo.Core.Result;
using Microsoft.AspNetCore.Authorization;
using Jabo.Log;

namespace Jabo.Core.Controllers
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
            _logger.Error("3325345");

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

        [HttpGet]
        public List<Dictionary<string, object>> GetMenuTree(string roleCode)
        {
            return _menuService.GetRoleMenu(roleCode);
        }
    }
}
