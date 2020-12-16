using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace QJB.Server.Result
{
    /// <summary>
    /// 表示一个类，该类用于将 JSON 格式的内容发送到响应。
    /// </summary>
    public class JsonHttpActionResult : IActionResult
    {
        private const string _successMessageCode = "S000000";
        private const string _errorMessageCode = "E000000";

        //返回值信息
        //public  JsonMessageData Data = new JsonMessageData();
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

        /// <summary>
        /// 设置datavalue
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public JsonHttpActionResult SetData(object data)
        {
            DataValue = data;
            return this;
        }

        /// <summary>
        /// 设置执行标志(false:失败;true:成功)
        /// </summary>
        /// <param name="IsSuccess"></param>
        /// <returns></returns>
        public JsonHttpActionResult SetResult(bool IsSuccess = true)
        {
            Result = IsSuccess;
            return this;
        }

        /// <summary>
        /// 设置返回消息
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public JsonHttpActionResult SetMessage(string message)
        {
            Message = message;
            return this;
        }

        /// <summary>
        /// 设置返回消息
        /// </summary>
        /// <param name="messageCode"></param>
        /// <returns></returns>
        public JsonHttpActionResult SetMessageCode(string messageCode)
        {
            MessageCode = messageCode;
            return this;
        }

        public JsonHttpActionResult SucceedMessage(string message = "执行成功！")
        {
            SetResult(true)
            .SetMessage(message)
            .SetMessageCode(_successMessageCode);

            return this;
        }

        public JsonHttpActionResult ErrorMessage(string message = "系统异常！")
        {
            SetResult(false)
            .SetMessage(message)
            .SetMessageCode(_errorMessageCode);

            return this;
        }

        public Task ExecuteResultAsync(ActionContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            HttpResponse response = context.HttpContext.Response;

            response.ContentType = "application/json";

            var obj = new { Result, DataValue = JsonConvert.SerializeObject(DataValue), Message, MessageCode };

            return response.WriteAsync(JsonConvert.SerializeObject(obj), Encoding.UTF8);
        }
    }
}
