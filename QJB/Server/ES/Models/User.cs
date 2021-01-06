using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QJB.Server.ES.Models
{
    public class User
    {
        [Text]
        public string name { get; set; }
        public int age { get; set; }
        [Keyword]
        public string mail { get; set; }
        [Text]
        public string hobby { get; set; }
    }
}
