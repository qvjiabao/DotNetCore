using System;
using System.IO;
using System.Reflection;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Jabo.Tools
{
    public class XmlTool
    {
        public XmlTool()
        {
        }
        /// <summary>
        /// 将自定义对象序列化为XML字符串
        /// </summary>
        /// <param name="myObject">自定义对象实体</param>
        /// <returns>序列化后的XML字符串</returns>
        public static string SerializeToXml<T>(T myObject)
        {
            if (myObject != null)
            {
                XmlSerializer xs = new XmlSerializer(typeof(T));

                MemoryStream stream = new MemoryStream();
                XmlTextWriter writer = new XmlTextWriter(stream, Encoding.UTF8);
                writer.Formatting = Formatting.None;//缩进
                xs.Serialize(writer, myObject);

                stream.Position = 0;
                StringBuilder sb = new StringBuilder();
                using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        sb.Append(line);
                    }
                    reader.Close();
                }
                writer.Close();
                return sb.ToString();
            }
            return string.Empty;
        }

        /// <summary>
        /// 将XML字符串反序列化为对象
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="xml">XML字符</param>
        /// <returns></returns>
        public static T DeserializeToObject<T>(string xml)
        {
            try
            {
                T myObject;
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                StringReader reader = new StringReader(xml);
                myObject = (T)serializer.Deserialize(reader);
                reader.Close();
                return myObject;
            }
            catch (Exception ex)
            {
                return default(T);
            }
        }

        /// <summary>
        /// 将XML字符串反序列化为对象
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="xml">XML字符</param>
        /// <returns></returns>
        public static T WeChatDeserializeToObject<T>(string xml)
        {
            try
            {
                //构造xml对象
                XmlDocument doc = new XmlDocument();

                //解析XML数据
                doc.LoadXml(xml);

                XmlElement rootElement = doc.DocumentElement;//获取根节点

                T t = Activator.CreateInstance<T>();

                PropertyInfo[] properties = t.GetType().GetProperties();

                foreach (var item in properties)
                {

                    var value = rootElement.SelectSingleNode(item.Name).InnerText;

                    if (!item.PropertyType.IsGenericType)
                    {
                        //非泛型
                        item.SetValue(t, string.IsNullOrEmpty(value)
                                      ? null : Convert.ChangeType(value, item.PropertyType), null);
                    }
                    else
                    {
                        //泛型Nullable<>
                        Type genericTypeDefinition = item.PropertyType.GetGenericTypeDefinition();
                        if (genericTypeDefinition == typeof(Nullable<>))
                        {
                            item.SetValue(t, string.IsNullOrEmpty(value)
                                          ? null : Convert.ChangeType(value, Nullable.GetUnderlyingType(item.PropertyType)), null);
                        }
                    }
                }

                return t;
            }
            catch (Exception ex)
            {
                return default(T);
            }
        }
    }
}
