﻿using Jabo.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jabo.IServices
{
    public interface IMenuService
    {
        IEnumerable<MenuModel> GetAllMenu();
    }
}
