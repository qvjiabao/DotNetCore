using System;
using System.Collections.Generic;
using System.Text;

namespace QJB.Dapper.Attribute
{
    /// <summary>
    /// Optional IgnoreSelect attribute.
    /// Custom for Dapper.SimpleCRUD to exclude a property from Select methods
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class IgnoreSelectAttribute : System.Attribute
    {
    }
}
