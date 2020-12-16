using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;

namespace QJB.LogExtend.Common
{
    internal class RequestHelpers
    {
        /// <summary>
        /// 组装普通文本请求参数。
        /// </summary>
        /// <param name="parameters">Key-Value形式请求参数字典</param>
        /// <returns>URL编码后的请求数据</returns>
        public static string BuildQuery(IDictionary<string, string> parameters)
        {
            StringBuilder postData = new StringBuilder();
            bool hasParam = false;

            IEnumerator<KeyValuePair<string, string>> dem = parameters.GetEnumerator();
            while (dem.MoveNext())
            {
                string name = dem.Current.Key;
                string value = dem.Current.Value;
                // 忽略参数名或参数值为空的参数
                if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(value))
                {
                    if (hasParam)
                    {
                        postData.Append("&");
                    }

                    postData.Append(name);
                    postData.Append("=");
                    postData.Append(HttpUtility.UrlEncode(value));
                    hasParam = true;
                }
            }

            return postData.ToString();
        }

        /// <summary>
        /// 执行HTTP POST请求。
        /// 对参数值执行UrlEncode
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <param name="parameters">请求参数</param>
        /// <returns>HTTP响应</returns>
        public static string DoPost(string url, IDictionary<string, string> parameters)
        {
            HttpWebRequest req = GetWebRequest(url, "POST");
            req.ContentType = "application/x-www-form-urlencoded;charset=utf-8";

            byte[] postData = Encoding.UTF8.GetBytes(BuildQuery(parameters));
            Stream reqStream = req.GetRequestStream();
            reqStream.Write(postData, 0, postData.Length);
            reqStream.Close();

            HttpWebResponse rsp = null;
            rsp = (HttpWebResponse)req.GetResponse();

            Encoding encoding = Encoding.GetEncoding(rsp.CharacterSet);
            return GetResponseAsString(rsp, encoding);
        }

        /// <summary>
        /// 执行HTTP POST请求。
        /// 该方法在执行post时不对请求数据进行任何编码（UrlEncode）
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <param name="data">请求数据</param>
        /// <returns>HTTP响应</returns>
        public static string DoPost(string url, string data)
        {
            HttpWebRequest req = GetWebRequest(url, "POST");
            req.ContentType = "application/x-www-form-urlencoded;charset=utf-8";

            byte[] postData = Encoding.UTF8.GetBytes(data);
            Stream reqStream = req.GetRequestStream();
            reqStream.Write(postData, 0, postData.Length);
            reqStream.Close();

            HttpWebResponse rsp = null;
            rsp = (HttpWebResponse)req.GetResponse();

            Encoding encoding = Encoding.GetEncoding(rsp.CharacterSet);
            return GetResponseAsString(rsp, encoding);
        }
        /// <summary>
        /// post数据 T messagepack序列化格式 减少传输数据大小
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <param name="model"></param>
        public static void DoPost<T>(string url, T model)
        {
            var client = new HttpClient();
            //var messagePackMediaTypeFormatter = new MessagePackMediaTypeFormatter(ContractlessStandardResolver.Instance);
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            request.Content = new StringContent(JsonConvert.SerializeObject(model));
            request.Content.Headers.ContentType.MediaType = "application/json";
            string encoded = Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1").GetBytes("qujiabao:123456"));
            request.Headers.Add("Authorization", "Basic" + encoded);
            client.SendAsync(request);

        }

        /// <summary>
        /// 执行HTTP POST请求。
        /// 该方法在执行post时不对请求数据进行任何编码（UrlEncode）
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <param name="data">请求数据</param>
        /// <returns>HTTP响应</returns>
        public static string DoPostJson(string url, string data)
        {
            HttpWebRequest req = GetWebRequest(url, "POST");
            req.ContentType = "application/json;charset=UTF-8";
            req.Accept = "application/json";
            byte[] postData = Encoding.UTF8.GetBytes(data);
            Stream reqStream = req.GetRequestStream();
            reqStream.Write(postData, 0, postData.Length);
            reqStream.Close();

            HttpWebResponse rsp = null;
            rsp = (HttpWebResponse)req.GetResponse();

            Encoding encoding = Encoding.GetEncoding(rsp.CharacterSet);
            return GetResponseAsString(rsp, encoding);
        }
        /// <summary>
        /// 执行HTTP GET请求。
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <param name="parameters">请求参数</param>
        /// <returns>HTTP响应</returns>
        public static string DoGet(string url, IDictionary<string, string> parameters)
        {
            if (parameters != null && parameters.Count > 0)
            {
                if (url.Contains("?"))
                {
                    url = url + "&" + BuildQuery(parameters);
                }
                else
                {
                    url = url + "?" + BuildQuery(parameters);
                }
            }

            HttpWebRequest req = GetWebRequest(url, "GET");
            req.ContentType = "application/x-www-form-urlencoded;charset=utf-8";

            HttpWebResponse rsp = null;
            rsp = (HttpWebResponse)req.GetResponse();

            Encoding encoding = Encoding.GetEncoding(rsp.CharacterSet);
            return GetResponseAsString(rsp, encoding);
        }

        public static HttpWebRequest GetWebRequest(string url, string method)
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            req.Method = method;
            return req;
        }

        /// <summary>
        /// 把响应流转换为文本。
        /// </summary>
        /// <param name="rsp">响应流对象</param>
        /// <param name="encoding">编码方式</param>
        /// <returns>响应文本</returns>
        public static string GetResponseAsString(HttpWebResponse rsp, Encoding encoding)
        {
            Stream stream = null;
            StreamReader reader = null;

            try
            {
                // 以字符流的方式读取HTTP响应
                stream = rsp.GetResponseStream();
                reader = new StreamReader(stream, encoding);
                return reader.ReadToEnd();
            }
            finally
            {
                // 释放资源
                if (reader != null) reader.Close();
                if (stream != null) stream.Close();
                if (rsp != null) rsp.Close();
            }
        }

        public static string GetUrlData(string url, string encoding, out long logSize)
        {
            logSize = 0;
            string return_value = string.Empty;
            try
            {
                HttpWebRequest wq = WebRequest.Create(url) as HttpWebRequest;
                if (wq == null)
                {
                    return return_value;
                }
                wq.Credentials = CredentialCache.DefaultCredentials;
                wq.CookieContainer = new CookieContainer();
                wq.ContentType = "text/html";
                wq.Method = "GET";
                wq.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:22.0) Gecko/20100101 Firefox/22.0";
                wq.Host = new Uri(url).Host;
                wq.Timeout = 10000;
                try
                {
                    HttpWebResponse rep = wq.GetResponse() as HttpWebResponse;
                    logSize = rep.ContentLength;
                    Stream responseStream = rep.GetResponseStream();
                    if (rep.ContentEncoding.ToLower().Contains("gzip"))
                    {
                        responseStream = new GZipStream(responseStream, CompressionMode.Decompress);
                    }
                    else if (rep.ContentEncoding.ToLower().Contains("deflate"))
                    {
                        responseStream = new DeflateStream(responseStream, CompressionMode.Decompress);
                    }
                    StreamReader reader = new StreamReader(responseStream, Encoding.GetEncoding(encoding));
                    return_value = reader.ReadToEnd();

                    responseStream.Close();
                    reader.Close();
                    rep.Close();
                }
                catch (Exception)
                {
                    return "nolog";
                }
            }
            catch (WebException ex)
            {
                return_value = "error_error";
            }
            return return_value;
        }
    }
}
