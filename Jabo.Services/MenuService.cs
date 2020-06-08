using Jabo.IRepository;
using Jabo.IServices;
using Jabo.Models;
using System;
using System.Collections.Generic;
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
            return _menuRepository.GetAllMenu();
        }
    }
}
