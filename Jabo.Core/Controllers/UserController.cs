using AutoMapper;
using Jabo.Core.ViewModels;
using Jabo.IServices;
using Jabo.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;

namespace Jabo.Core.Controllers
{
    public class UserController : BaseController
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IMapper mapper, IUserService userService)
        {
            _userService = userService;
            _mapper = mapper;
        }

        public IActionResult UserList()
        {
            return View();
        }

        [HttpGet]
        public Hashtable GetUserList(string displayName, int limit = 0, int page = 1)
        {
            var all = _userService.GetAllUsers(displayName);

            var list = all.Skip((page - 1) * limit).Take(limit);

            var convertList = _mapper.Map<IEnumerable<UserModel>, IEnumerable<UserVModel>>(list);

            var tab = new Hashtable();

            tab["count"] = all.Count();

            tab["data"] = convertList;

            tab["code"] = "0";

            return tab;
        }
    }
}
