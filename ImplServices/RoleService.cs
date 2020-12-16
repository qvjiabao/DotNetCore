using QJB.IRepository;
using QJB.IServices;
using QJB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jabo.Services
{
    public class RoleService : IRoleService
    {

        private IRoleRepository _roleRepository;
        private IMenuRepository _menuRepository;

        public RoleService(IRoleRepository roleRepository, IMenuRepository menuRepository)
        {
            _roleRepository = roleRepository;
            _menuRepository = menuRepository;
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

        public bool SaveRoleMenu(IEnumerable<MenuModel> rolelist, string roleCode, string userName, string displayName)
        {
            var success = true;

            try
            {
                _menuRepository.RemoveRoleMenu(roleCode); //删除所有关系

                foreach (var item in rolelist)
                {
                    var model = new RoleMenuModel();
                    model.MenuCode = item.MenuGuid;
                    model.RoleCode = roleCode;
                    model.CreateDate = DateTime.Now;
                    model.CreateUserName = userName;
                    model.CreateDisplayName = displayName;

                    _menuRepository.CreateRoleMenu(model);  //新增关系

                    foreach (var child in item.Children)
                    {
                        model = new RoleMenuModel();
                        model.MenuCode = child.MenuGuid;
                        model.RoleCode = roleCode;
                        model.CreateDate = DateTime.Now;
                        model.CreateUserName = userName;
                        model.CreateDisplayName = displayName;

                        _menuRepository.CreateRoleMenu(model); //新增关系
                    }
                }
            }
            catch (Exception)
            {
                success = false;
            }

            return success;
        }
    }
}
