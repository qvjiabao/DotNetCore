using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QJB.Shared.Attribute
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class DisabledAttribute : System.Attribute
    {
        /// <summary>
        /// Name of the column
        /// </summary>
        public bool Disabled { get; set; }
    }
}
