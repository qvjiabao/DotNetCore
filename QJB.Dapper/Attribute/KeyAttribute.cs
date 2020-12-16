﻿using System;
using System.Collections.Generic;
using System.Text;

namespace QJB.Dapper.Attribute
{
    /// <summary>
    /// Optional Key attribute.
    /// You can use the System.ComponentModel.DataAnnotations version in its place to specify the Primary Key of a poco
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class KeyAttribute : System.Attribute
    {
    }
}
