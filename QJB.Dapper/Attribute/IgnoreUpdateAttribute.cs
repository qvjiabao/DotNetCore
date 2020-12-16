using System;
using System.Collections.Generic;
using System.Text;

namespace QJB.Dapper.Attribute
{
    /// <summary>
    /// Optional IgnoreUpdate attribute.
    /// Custom for Dapper.SimpleCRUD to exclude a property from Update methods
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class IgnoreUpdateAttribute : System.Attribute
    {
    }
}
