﻿using System;
using System.Collections.Generic;
using System.Text;

namespace QJB.Dapper.Attribute
{
    /// <summary>
    /// Optional NotMapped attribute.
    /// You can use the System.ComponentModel.DataAnnotations version in its place to specify that the property is not mapped
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class NotMappedAttribute : System.Attribute
    {
    }
}
