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
        public string MenuGuid { get; set; }
        public string Title { get; set; }
        public string Href { get; set; }
        public string Target { get; set; }
        public string Icon { get; set; }
    }
}
