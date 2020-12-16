using QJB.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace QJB.IRepository
{
    public interface IRoleRepository
    {
        /// <summary>
        /// 获取所有角色
        /// </summary>
        /// <returns></returns>
        IEnumerable<RoleModel> GetAllRoles(string where);

        /// <summary>
        /// 删除角色
        /// </summary>
        /// <param name="roleCode"></param>
        /// <returns></returns>
        int RemoveRoleByCode(string roleCodes, string userName, string displayName);

        /// <summary>
        /// 新增角色
        /// </summary>
        /// <param name="roleCode"></param>
        /// <returns></returns>
        int CreateRole(RoleModel role);

        /// <summary>
        /// 编辑角色
        /// </summary>
        /// <param name="roleCode"></param>
        /// <returns></returns>
        int UpdateRole(RoleModel role);

        /// <summary>
        /// 检查角色名是否存在
        /// </summary>
        /// <param name="roleCode"></param>
        /// <returns></returns>
        bool ExistxRoleName(string roleName, string roleCode = "");

        /// <summary>
        /// 根据编码获取角色
        /// </summary>
        /// <param name="roleCode"></param>
        /// <returns></returns>
        RoleModel GetRoleByRoleCode(string roleCode);
    }
}
