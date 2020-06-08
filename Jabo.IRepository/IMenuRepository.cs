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
    }
}
