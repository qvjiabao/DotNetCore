using QJB.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace QJB.IServices
{
    public interface IRoleService
    {
        /// <summary>
        /// 检查角色是否存在
        /// </summary>
        /// <param name="roleName"></param>
        /// <param name="roleCode"></param>
        /// <returns></returns>
        bool ExistsRoleName(string roleName, string roleCode = "");

        /// <summary>
        /// 保存角色
        /// </summary>
        /// <param name="roleModel"></param>
        /// <returns></returns>
        bool SaveRole(RoleModel roleModel);

        /// <summary>
        /// 保存角色菜单关系
        /// </summary>
        /// <param name="roleModel"></param>
        /// <returns></returns>
        bool SaveRoleMenu(IEnumerable<MenuModel> list, string roleCode, string userName, string displayName);

        /// <summary>
        /// 根据编码获取角色
        /// </summary>
        /// <returns></returns>
        RoleModel GetRoleByRoleCode(string roleCode);

        /// <summary>
        /// 获取所有角色
        /// </summary>
        /// <param name="displayName"></param>
        /// <returns></returns>
        IEnumerable<RoleModel> GetAllRoles(string roleName);

        /// <summary>
        /// 删除角色
        /// </summary>
        /// <param name="roleCode"></param>
        /// <returns></returns>
        bool RemoveRoleByCode(IEnumerable<RoleModel> list, string userName, string displayName);
    }
}
