﻿using System;
using System.Collections.Generic;
using System.Text;

namespace QJB.Dapper.Attribute
{
    /// <summary>
    /// Optional IgnoreInsert attribute.
    /// Custom for Dapper.SimpleCRUD to exclude a property from Insert methods
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class IgnoreInsertAttribute : System.Attribute
    {
    }
}
