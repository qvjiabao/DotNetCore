using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QJB.Shared
{
    public class MenuVModel
    {
        public string Title { get; set; }
        public string Url { get; set; }
        public string MenuGuid { get; set; }
        public string Icon { get; set; }
        public IEnumerable<MenuVModel> Children { get; set; }
    }
}
