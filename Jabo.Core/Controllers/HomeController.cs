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

namespace Jabo.Core.Controllers
{
    public class HomeController : Controller
    {

        private readonly IMenuService _menuService;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public HomeController(IMapper mapper, IMenuService menuService, IUserService userService)
        {
            _menuService = menuService;
            _mapper = mapper;
            _userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Welcome()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        public bool VerifyLogin()
        {
            var a = _userService.GetUserByUserNameAndPwd("234", "234");

            return a != null;
        }


        public IEnumerable<MenuVModel> GetAllMenu()
        {
            var menuList = _menuService.GetAllMenu();

            var list = _mapper.Map<IEnumerable<MenuModel>, IEnumerable<MenuVModel>>(menuList);

            return list;
        }
    }
}
