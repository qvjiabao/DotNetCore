using System;
using System.Collections.Generic;
using System.Text;

namespace Jabo.MongoDB.Model.AppSettings
{
    /// <summary>
    /// 数据库配置信息
    /// </summary>
    public class DBSettings
    {
        /// <summary>
        /// mongodb connectionstring
        /// </summary>
        public string ConnectionString { get; set; }
        /// <summary>
        /// mongodb database
        /// </summary>
        public string Database { get; set; }
        /// <summary>
        /// 日志collection
        /// </summary>
        public string LogCollection { get; set; }
    }
}
