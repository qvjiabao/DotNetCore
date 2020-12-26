
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QJB.Shared.Core
{
        /// <summary>
        /// 表示一个类，该类用于将 JSON 格式的内容发送到响应。
        /// </summary>
        public class HttpJsonResult 
        {

            /// <summary>
            /// 是否成功标志0:失败;1:成功
            /// </summary>
            public bool Result { get; set; }

            /// <summary>
            /// 获取或设置数据
            /// </summary>
            ///<returns>数据。</returns>
            public object DataValue { get; set; }

            /// <summary>
            /// 返回消息编码
            /// </summary>
            public string MessageCode { get; set; }
            /// <summary>
            /// 返回消息
            /// </summary>
            public string Message { get; set; }

        }
}
