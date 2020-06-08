using ProtoBuf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Web;

namespace Jabo.Tools
{
    public class ProtoBufHelper
    {

        /// <summary>
        /// 序列化
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static byte[] Serialize(object obj)
        {
            //if (obj == null)
            //    return null;

            //var binaryFormatter = new BinaryFormatter();
            //using (var memoryStream = new MemoryStream())
            //{
            //    binaryFormatter.Serialize(memoryStream, obj);
            //    var data = memoryStream.ToArray();
            //    return data;
            //}
            using (MemoryStream ms = new MemoryStream())
            {
                Serializer.Serialize(ms, obj);
                return ms.ToArray();
            }
        }
        /// <summary>
        /// 反序列化
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        public static T DeSerialize<T>(byte[] data)
        {
            using (MemoryStream ms = new MemoryStream(data))
            {
                T t = Serializer.Deserialize<T>(ms);
                return t;
            }

            //if (data == null)
            //    return default(T);

            //var binaryFormatter = new BinaryFormatter();
            //using (var memoryStream = new MemoryStream(data))
            //{
            //    var result = (T)binaryFormatter.Deserialize(memoryStream);
            //    return result;
            //}
        }
    }
}