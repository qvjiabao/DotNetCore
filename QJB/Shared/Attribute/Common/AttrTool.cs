using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace QJB.Shared.Attribute.Common
{
    /// <summary>
    /// 获取特性工具类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public static class AttrTool<T>
    {
        /// <summary>
        /// 获取特性Name属性
        /// </summary>
        /// <typeparam name="Result"></typeparam>
        /// <param name="expression"></param>
        /// <returns></returns>
        public static bool GetPropDisabled<Result>(Expression<Func<T, Result>> expression)
        {
            var body = expression.Body as MemberExpression;

            var attr = body.Member.CustomAttributes.FirstOrDefault(t => t.AttributeType == typeof(DisabledAttribute));

            if (attr == null) return false;

            var property = attr.NamedArguments.FirstOrDefault(t => t.MemberName == "Value");

            return property.TypedValue.Value == null ? false : Convert.ToBoolean(property.TypedValue.Value);
        }


    }
}
