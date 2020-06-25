using Jabo.IRepository;
using Jabo.IServices;
using Jabo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jabo.Services
{
    public class RoleService : IRoleService
    {

        private IRoleRepository _roleRepository;

        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public bool ExistsRoleName(string roleName, string roleCode = "")
        {
            return _roleRepository.ExistxRoleName(roleName, roleCode);
        }

        public IEnumerable<RoleModel> GetAllRoles(string roleName)
        {
            var sql = string.Empty;

            if (!string.IsNullOrWhiteSpace(roleName))
            {
                sql = $" and  RoleName like '%{roleName}%' ";
            }

            var list = _roleRepository.GetAllRoles(sql);

            return list;
        }

        public RoleModel GetRoleByRoleCode(string roleCode)
        {
            return _roleRepository.GetRoleByRoleCode(roleCode);
        }

        public bool RemoveRoleByCode(IEnumerable<RoleModel> list, string userName, string displayName)
        {
            if (list.Count() == 0) return false;

            var str = list.Aggregate(string.Empty, (s, n) => s += $",'{n.RoleCode}'");

            return _roleRepository.RemoveRoleByCode(str.Substring(1), userName, displayName) > 0;
        }

        public bool SaveRole(RoleModel roleModel)
        {
            if (string.IsNullOrWhiteSpace(roleModel.RoleCode))
            {
                roleModel.RoleCode = Guid.NewGuid().ToString();

                return _roleRepository.CreateRole(roleModel) > 0;
            }
            else
            {
                var model = _roleRepository.GetRoleByRoleCode(roleModel.RoleCode);
                model.RoleName = roleModel.RoleName;
                model.Describe = roleModel.Describe;
                model.ModifyDate = roleModel.ModifyDate;
                model.ModifyDisplayName = roleModel.ModifyDisplayName;
                model.ModifyUserName = roleModel.ModifyUserName;

                return _roleRepository.UpdateRole(model) > 0;
            }
        }
    }
}
