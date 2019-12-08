using System;
namespace Jabo.Tools
{
    public class DateTool
    {
        public DateTool()
        {
        }

        /// <summary>
        /// 获取时间戳
        /// </summary>
        /// <returns></returns>
        public static long GetTimeStamp()
        {
            return GetTimeStamp(DateTime.Now);
        }

        /// <summary>
        /// 获取指定时间戳
        /// </summary>
        /// <returns>日期</returns>
        public static long GetTimeStamp(DateTime dateTime)
        {
            TimeSpan ts = dateTime.ToUniversalTime() - new DateTime(1970, 1, 1);
            return (long)ts.TotalMilliseconds;     //精确到毫秒
        }
    }
}
