using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MyWpf.Common
{
    public class JsonHelper
    {
        /// <summary>
        /// 将字符串序列化为json
        /// </summary>
        /// <param name="token"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string StrToJson(string token,string name)
        {
            return JsonConvert.SerializeObject(new { Token = token, Name = name });
        }

        /// <summary>
        /// 将json字符串转为实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json"></param>
        /// <returns></returns>
        public static T JosnToModel<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }

        /// <summary>
        /// 将json对象存入json文件
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path"></param>
        /// <returns></returns>
        public static void SaveToJson<T>(string path,T jsonModel)
        {
            if (!File.Exists(path))
            {
                File.Create(path);
            }
            File.WriteAllText(path, JsonConvert.SerializeObject(jsonModel));
        }

        /// <summary>
        /// 读取json文件,返回序列化对象
        /// </summary>
        public static T ReadJsonFileToStr<T>(string path)
        {
            string strs= File.ReadAllText(path);
            return JsonConvert.DeserializeObject<T>(strs);
        }
    }
}
