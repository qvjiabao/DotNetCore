﻿using Microsoft.Extensions.DependencyInjection;
using QJB.LogExtend;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QJB.Server.Extension
{
    /// <summary>
    /// 日志服务注入扩展类
    /// </summary>
    public static class LoggerServiceExtension
    {
        /// <summary>
        /// 注入日志服务
        /// </summary>
        /// <param name="service">IServiceCollection</param>
        /// <param name="logSource">日志来源，默认日志来源为调用方法所在类：namespace.classname</param>
        /// <returns></returns>
        public static IServiceCollection AddLoggerService(this IServiceCollection service, string logSource = null)
        {
            return service.AddTransient(factory => Logger.GetLogger(logSource));
        }
    }
}
