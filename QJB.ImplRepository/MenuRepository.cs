using Dapper;
using QJB.Dapper;
using QJB.ImplRepository;
using QJB.IRepository;
using QJB.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace QJB.ImplRepository
{
    public class MenuRepository : BaseRepository, IMenuRepository
    {

        public IEnumerable<MenuModel> GetAllMenu()
        {
            using (var connection = Dapper.DataBase.GetOpenConnection(GetConnectionString))
            {
                var list = connection.GetList<MenuModel>(" order by sort ");

                return list;
            }
        }

        public IEnumerable<MenuModel> GetRoleMenu(string roleCode)
        {
            using (var connection = Dapper.DataBase.GetOpenConnection(GetConnectionString))
            {
                var list = connection.Query<MenuModel>(@"select B.* from YX_RoleMenu A 
                    inner join YX_Menu B on A.MenuCode = B.MenuGuid
                    where A.RoleCode = @roleCode", new { roleCode });
                return list;
            }
        }

        public int RemoveRoleMenu(string roleCode)
        {
            using (var connection = DataBase.GetOpenConnection(GetConnectionString))
            {
                var count = connection.Execute($@" DELETE YX_RoleMenu where RoleCode = @roleCode ", new { roleCode });

                return count;
            }
        }
        public int CreateRoleMenu(RoleMenuModel role)
        {
            using (var connection = DataBase.GetOpenConnection(GetConnectionString))
            {
                var count = connection.Insert<RoleMenuModel>(role);

                return (int)count;
            }
        }
    }
}
