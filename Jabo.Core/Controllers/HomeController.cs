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
using Jabo.Core.Filter;

namespace Jabo.Core.Controllers
{

    [CheckLogin]
    public class HomeController : BaseController
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
            ViewBag.displayName = GetUser.DisplayName;

            return View();
        }
        public IActionResult Welcome()
        {
            return View();
        }

        public IEnumerable<MenuVModel> GetAllMenu()
        {
            var menuList = _menuService.GetAllMenu();

            var list = _mapper.Map<IEnumerable<MenuModel>, IEnumerable<MenuVModel>>(menuList);

            return list;
        }
    }
}
