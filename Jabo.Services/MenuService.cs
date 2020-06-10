using Jabo.IRepository;
using Jabo.IServices;
using Jabo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jabo.Services
{
    public class MenuService : IMenuService
    {

        private readonly IMenuRepository _menuRepository;

        public MenuService(IMenuRepository menuRepository)
        {
            _menuRepository = menuRepository;
        }

        public IEnumerable<MenuModel> GetAllMenu()
        {
            var list = _menuRepository.GetAllMenu();

            var first = _menuRepository.GetAllMenu().Where(s => s.ParentGuid == "0");

            foreach (var item in first)
            {
                item.Children = list.Where(s => s.ParentGuid == item.MenuGuid);
            }
            return first;
        }
    }
}
