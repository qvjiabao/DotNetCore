using Jabo.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jabo.IRepository
{
    public interface IMenuRepository
    {
        /// <summary>
        /// 获取所有菜单
        /// </summary>
        /// <returns></returns>
        IEnumerable<MenuModel> GetAllMenu();

        /// <summary>
        /// 获取角色菜单关系
        /// </summary>
        /// <param name="roleCode"></param>
        /// <returns></returns>
        IEnumerable<MenuModel> GetRoleMenu(string roleCode);

        /// <summary>
        /// 删除角色菜单关系
        /// </summary>
        /// <param name="roleCode"></param>
        /// <returns></returns>
        int RemoveRoleMenu(string roleCode);

        /// <summary>
        /// 新增角色菜单关系
        /// </summary>
        /// <param name="roleCode"></param>
        /// <returns></returns>
        int CreateRoleMenu(RoleMenuModel role);
    }
}
