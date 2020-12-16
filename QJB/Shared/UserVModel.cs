using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace QJB.Shared
{
    public class UserVModel
    {
        public string UserCode { get; set; }

        public string UserName { get; set; }

        public string DisplayName { get; set; }

        public string Phone { get; set; }

        public string Sex { get; set; }

        public DateTime? CreateDate { get; set; }

        public string RoleCode { get; set; }
    }
}
