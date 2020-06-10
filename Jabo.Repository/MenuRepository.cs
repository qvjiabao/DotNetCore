using Jabo.Dapper;
using Jabo.IRepository;
using Jabo.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jabo.Repository
{
    public class MenuRepository : IMenuRepository
    {
        public IEnumerable<MenuModel> GetAllMenu()
        {
            using (var connection = Dapper.DataBase.GetOpenConnection())
            {
                var list = connection.GetList<MenuModel>(" order by sort ");

                return list;
            }
        }
    }
}
