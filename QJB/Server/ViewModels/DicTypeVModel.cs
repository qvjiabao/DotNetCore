using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jabo.Core.ViewModels
{
    public class DicTypeVModel
    {
        public string id { get; set; }
        public string title { get; set; }
        public string field { get { return string.Empty; } }
        public bool spread { get { return true; } }
    }
}
