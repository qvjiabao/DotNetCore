﻿using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace QJB.Dapper
{
    public interface IColumnNameResolver
    {
        string ResolveColumnName(PropertyInfo propertyInfo, Func<string, string> encapsulate);
    }
}
