﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jabo.Core.ViewModels
{
    public class RoleVModel
    {
        public string roleCode { get; set; }
        public string roleName { get; set; }
        public string describe { get; set; }
        public DateTime? createDate { get; set; }
    }
}
