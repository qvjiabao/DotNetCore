using AutoMapper;
using Jabo.Core.Filter;
using Jabo.Core.Result;
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
    [CheckLogin]
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

        public IActionResult UserView()
        {
            return View();
        }
        public IActionResult UserSave()
        {
            return View();
        }

        [HttpGet]
        public UserVModel GetUserByCode(string userCode)
        {
            var user = _userService.GetUserByUserCode(userCode);

            var vmodel = _mapper.Map<UserVModel>(user);

            return vmodel;
        }

        [HttpPost]
        public JsonHttpActionResult SaveUserInfo(UserModel model)
        {
            var j = new JsonHttpActionResult();
            var success = true;
            if (string.IsNullOrWhiteSpace(model.UserCode))
            {
                //检查用户账号是否存在
                var checkUserName = _userService.ExistsUserName(model.UserName);
                if (checkUserName)
                    return j.ErrorMessage("用户账号已存在");
                model.CreateDate = DateTime.Now;
                model.CreateUserName = UserInfo.UserName;
                model.CreateDisplayName = UserInfo.DisplayName;
                model.IsDeleted = false;

            }
            else
            {
                //检查用户账号是否存在
                var checkUserName = _userService.ExistsUserName(model.UserName, model.UserCode);
                if (checkUserName)
                    return j.ErrorMessage("用户账号已存在");
                model.ModifyDate = DateTime.Now;
                model.ModifyUserName = UserInfo.UserName;
                model.ModifyDisplayName = UserInfo.DisplayName;
            }

            success = _userService.SaveUser(model);

            j.SetData(success);

            return success ? j.SucceedMessage() : j.ErrorMessage();
        }

        [HttpPost]
        public JsonHttpActionResult RemoveUserByCode(IEnumerable<UserModel> list)
        {
            var j = new JsonHttpActionResult();

            if (list.Count() == 0)
            {
                return j.ErrorMessage("请选择要删除的用户");
            }

            var user = UserInfo;

            var success = _userService.RemoveUserByCode(list, user.UserName, user.DisplayName);

            j.SetData(success);

            return success ? j.SucceedMessage() : j.ErrorMessage();
        }

        [HttpGet]
        public Hashtable GetUserList(string displayName, int limit = 10, int page = 1)
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
