using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Jabo.Core.Filter;
using Jabo.Core.Result;
using Jabo.Core.ViewModels;
using Jabo.IServices;
using Jabo.Models;
using Microsoft.AspNetCore.Mvc;

namespace Jabo.Core.Controllers
{
    [CheckLogin]
    public class RoleController : BaseController
    {
        private readonly IRoleService _roleService;
        private readonly IMapper _mapper;

        public RoleController(IMapper mapper, IRoleService roleService)
        {
            _roleService = roleService;
            _mapper = mapper;
        }

        public IActionResult RoleView()
        {
            return View();
        }
        public IActionResult RoleSave()
        {
            return View();
        }

        public IActionResult RoleList()
        {
            return View();
        }
        public IActionResult RoleMenuList()
        {
            return View();
        }

        [HttpGet]
        public RoleVModel GetRoleByCode(string roleCode)
        {
            var user = _roleService.GetRoleByRoleCode(roleCode);

            var vmodel = _mapper.Map<RoleVModel>(user);

            return vmodel;
        }
        [HttpPost]
        public JsonHttpActionResult SaveRoleMenu(IEnumerable<MenuTreeVModel> list, string roleCode)
        {
            var j = new JsonHttpActionResult();

            var convertList = _mapper.Map<IEnumerable<MenuModel>>(list);

            var user = UserInfo;

            var success = _roleService.SaveRoleMenu(convertList, roleCode, user.UserName, user.DisplayName);

            j.SetData(success);

            return success ? j.SucceedMessage() : j.ErrorMessage();
        }

        [HttpPost]
        public JsonHttpActionResult SaveRoleInfo(RoleModel model)
        {
            var j = new JsonHttpActionResult();
            var success = true;
            if (string.IsNullOrWhiteSpace(model.RoleCode))
            {
                //检查用户账号是否存在
                var checkUserName = _roleService.ExistsRoleName(model.RoleName);
                if (checkUserName)
                    return j.ErrorMessage("角色名称已存在");
                model.CreateDate = DateTime.Now;
                model.CreateUserName = UserInfo.UserName;
                model.CreateDisplayName = UserInfo.DisplayName;
                model.IsDeleted = false;

            }
            else
            {
                //检查用户账号是否存在
                var checkUserName = _roleService.ExistsRoleName(model.RoleName, model.RoleCode);
                if (checkUserName)
                    return j.ErrorMessage("角色名称已存在");
                model.ModifyDate = DateTime.Now;
                model.ModifyUserName = UserInfo.UserName;
                model.ModifyDisplayName = UserInfo.DisplayName;
            }

            success = _roleService.SaveRole(model);

            j.SetData(success);

            return success ? j.SucceedMessage() : j.ErrorMessage();
        }

        [HttpPost]
        public JsonHttpActionResult RemoveRoleByCode(IEnumerable<RoleModel> list)
        {
            var j = new JsonHttpActionResult();

            if (list.Count() == 0)
            {
                return j.ErrorMessage("请选择要删除的角色");
            }

            var user = UserInfo;

            var success = _roleService.RemoveRoleByCode(list, user.UserName, user.DisplayName);

            j.SetData(success);

            return success ? j.SucceedMessage() : j.ErrorMessage();
        }

        /// <summary>
        /// 获取角色分页列表
        /// </summary>
        /// <param name="displayName"></param>
        /// <param name="limit"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        [HttpGet]
        public Hashtable GetRolePage(string roleName, int limit = 0, int page = 1)
        {
            var all = _roleService.GetAllRoles(roleName);

            var list = all.Skip((page - 1) * limit).Take(limit);

            var convertList = _mapper.Map<IEnumerable<RoleModel>, IEnumerable<RoleVModel>>(list);

            var tab = new Hashtable();

            tab["count"] = all.Count();

            tab["data"] = convertList;

            tab["code"] = "0";

            return tab;
        }

        /// <summary>
        /// 获取角色列表
        /// </summary>
        /// <param name="displayName"></param>
        /// <param name="limit"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        [HttpGet, HttpPost]
        public JsonHttpActionResult GetRoleList()
        {
            var list = _roleService.GetAllRoles(string.Empty);

            var convertList = _mapper.Map<IEnumerable<RoleModel>, IEnumerable<RoleVModel>>(list);

            var j = new JsonHttpActionResult();

            return j.SetData(convertList).SucceedMessage();
        }
    }
}