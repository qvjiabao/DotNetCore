using QJB.IRepository;
using QJB.IServices;
using QJB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;

namespace QJB.ImplService
{
    public class MenuService : IMenuService
    {

        private readonly IMenuRepository _menuRepository;

        public MenuService(IMenuRepository menuRepository)
        {
            _menuRepository = menuRepository;
        }

        public IEnumerable<MenuModel> GetAllMenu(string roleCode)
        {
            var list = _menuRepository.GetRoleMenu(roleCode);

            var first = list.Where(s => s.ParentGuid == "0").OrderBy(s => s.Sort);

            foreach (var item in first)
            {
                item.Children = list.Where(s => s.ParentGuid == item.MenuGuid).OrderBy(s => s.Sort);
            }
            return first;
        }

        public List<Dictionary<string, object>> GetRoleMenu(string roleCode)
        {
            var list = _menuRepository.GetAllMenu();

            var firstNode = _menuRepository.GetAllMenu().Where(s => s.ParentGuid == "0");

            var listDic = new List<Dictionary<string, object>>();

            var checkedMenuList = _menuRepository.GetRoleMenu(roleCode);

            foreach (var first in firstNode)
            {
                first.Children = list.Where(s => s.ParentGuid == first.MenuGuid);

                var childList = new List<Dictionary<string, object>>();

                foreach (var item in first.Children)
                {
                    var childCheck = checkedMenuList.Any(s => s.MenuGuid == item.MenuGuid);

                    var childDic = new Dictionary<string, object>();

                    childDic.Add("checked", childCheck);
                    childDic.Add("title", item.Title);
                    childDic.Add("id", item.MenuGuid);
                    childDic.Add("field", "");
                    childDic.Add("spread", true);

                    childList.Add(childDic);
                }

                var check = checkedMenuList.Any(s => s.MenuGuid == first.MenuGuid);

                var dic = new Dictionary<string, object>();
                dic.Add("checked", check);
                dic.Add("title", first.Title);
                dic.Add("id", first.MenuGuid);
                dic.Add("field", "");
                dic.Add("spread", true);
                dic.Add("children", childList);

                listDic.Add(dic);
            }

            return listDic;
        }
    }
}
