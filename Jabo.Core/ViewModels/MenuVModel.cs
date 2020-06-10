using Jabo.Dapper;
using Jabo.Dapper.Attribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jabo.Core.ViewModels
{
    public class MenuVModel
    {
        public string title { get; set; }
        public string href { get; set; }
        public string target { get; set; }
        public string icon { get; set; }
        public IEnumerable<MenuVModel> child { get; set; }
    }
}
