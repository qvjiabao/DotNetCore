using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace QJB.MongoDB.Model
{
    public class ResponseModel<T>
    {
        private HttpStatusCode _resultCode = HttpStatusCode.OK;
        private string _message = "请求成功";
        private T _data = default;
        /// <summary>
        /// 返回码
        /// </summary>
        public HttpStatusCode ResultCode
        {
            get { return _resultCode; }
            set { _resultCode = value; }
        }
        /// <summary>
        /// 结果说明
        /// </summary>
        public string Message
        {
            get { return _message; }
            set { _message = value; }
        }
        /// <summary>
        /// 返回的数据
        /// </summary>
        public T Data
        {
            get { return _data; }
            set { _data = value; }
        }
    }
}
