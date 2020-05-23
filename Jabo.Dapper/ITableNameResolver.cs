using System;
using System.Collections.Generic;
using System.Text;

namespace Jabo.Dapper
{
    public interface ITableNameResolver
    {
        string ResolveTableName(Type type, Func<string, string> encapsulate);
    }
}
