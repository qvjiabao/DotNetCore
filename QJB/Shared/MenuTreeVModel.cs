using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QJB.Shared
{
    public class MenuTreeVModel
    {
        public string id { get; set; }
        public string title { get; set; }
        public string field { get { return string.Empty; } }
        public bool spread { get { return true; } }
        public IEnumerable<MenuTreeVModel> children { get; set; }
    }
}
