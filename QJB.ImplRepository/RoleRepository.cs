using Dapper;
using QJB.Dapper;
using QJB.ImplRepository;
using QJB.IRepository;
using QJB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QJB.ImplRepository
{
    public class RoleRepository : BaseRepository, IRoleRepository
    {
        public int CreateRole(RoleModel role)
        {
            using (var connection = DataBase.GetOpenConnection(GetConnectionString))
            {
                var count = connection.Insert<RoleModel>(role);

                return (int)count;
            }
        }

        public bool ExistxRoleName(string roleName, string roleCode = "")
        {
            using (var connection = DataBase.GetOpenConnection(GetConnectionString))
            {
                if (string.IsNullOrWhiteSpace(roleCode))
                {
                    var model = connection.GetList<RoleModel>("where IsDeleted = 0 and RoleName = @roleName ",
                        new { roleName = roleName }).FirstOrDefault();

                    return model != null;
                }
                else
                {
                    var model = connection.GetList<RoleModel>("where IsDeleted = 0 and RoleName = @roleName and RoleCode <> @roleCodes",
                        new { roleName = roleName, roleCodes = roleCode }).FirstOrDefault();

                    return model != null;
                }
            }
        }

        public IEnumerable<RoleModel> GetAllRoles(string where)
        {
            using (var connection = DataBase.GetOpenConnection(GetConnectionString))
            {
                var list = connection.GetList<RoleModel>("where IsDeleted = 0 " + where + " order by CreateDate desc");

                return list;
            }
        }

        public RoleModel GetRoleByRoleCode(string roleCode)
        {
            using (var connection = DataBase.GetOpenConnection(GetConnectionString))
            {
                var model = connection.GetList<RoleModel>("where IsDeleted = 0 and RoleCode = @roleCode ",
                    new { roleCode = roleCode }).FirstOrDefault();

                return model;
            }
        }

        public int RemoveRoleByCode(string roleCodes, string userName, string displayName)
        {
            using (var connection = DataBase.GetOpenConnection(GetConnectionString))
            {
                var count = connection.Execute($@" UPDATE YX_Roles SET IsDeleted = 1,ModifyUserName = @modifyUserName,ModifyDisplayName = @modifyDisplayName
                    ,ModifyDate = @modifyDate where RoleCode in ({roleCodes})", new { modifyUserName = userName, modifyDisplayName = displayName, modifyDate = DateTime.Now });

                return count;
            }
        }

        public int UpdateRole(RoleModel role)
        {
            using (var connection = DataBase.GetOpenConnection(GetConnectionString))
            {
                var count = connection.Update<RoleModel>(role);

                return count;
            }
        }
    }
}
