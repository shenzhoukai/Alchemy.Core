using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Alchemy.Core.Extension;

namespace Alchemy.Core.Service
{
    public class JsonService
    {
        /// <summary>
        /// 写入JSON
        /// </summary>
        /// <param name="fi"></param>
        /// <param name="strValue"></param>
        public static void WriteJson(FileInfo fi, string strValue)
        {
            WriteJson(fi.FullName, strValue);
        }
        /// <summary>
        /// 写入JSON
        /// </summary>
        /// <param name="strJsonPath"></param>
        /// <param name="strValue"></param>
        public static void WriteJson(string strJsonPath, string strValue)
        {
            JObject jo = strValue.FromJson<JObject>();
            string output = JsonConvert.SerializeObject(jo, Formatting.Indented);
            File.WriteAllText(strJsonPath, output);
        }
        /// <summary>
        /// 写入JSON
        /// </summary>
        /// <param name="fi"></param>
        /// <param name="strValue"></param>
        public static void WriteJsonArray(FileInfo fi, string strValue)
        {
            WriteJsonArray(fi.FullName, strValue);
        }
        /// <summary>
        /// 写入JSON
        /// </summary>
        /// <param name="strJsonPath"></param>
        /// <param name="strValue"></param>
        public static void WriteJsonArray(string strJsonPath, string strValue)
        {
            JArray ja = strValue.FromJson<JArray>();
            string output = JsonConvert.SerializeObject(ja, Formatting.Indented);
            File.WriteAllText(strJsonPath, output);
        }
        /// <summary>
        /// 读取文件路径，写入Json内容
        /// </summary>
        /// <param name="fi"></param>
        /// <param name="strKey"></param>
        /// <param name="strValue"></param>
        public static void SetJson(FileInfo fi, string strKey, string strValue)
        {
            string strJson = File.ReadAllText(fi.FullName);
            SetJson(fi.FullName, strJson, strKey, strValue);
        }
        /// <summary>
        /// 读取文件路径，写入Json内容
        /// </summary>
        /// <param name="strJsonPath"></param>
        /// <param name="strJson"></param>
        /// <param name="strKey"></param>
        /// <param name="strValue"></param>
        public static void SetJson(string strJsonPath, string strJson, string strKey, string strValue)
        {
            JObject jo = strJson.FromJson<JObject>();
            jo[strKey] = strValue.FromJson<JToken>();
            string output = JsonConvert.SerializeObject(jo, Formatting.Indented);
            File.WriteAllText(strJsonPath, output);
        }
        /// <summary>
        /// 读取文件路径，写入Json内容
        /// </summary>
        /// <param name="fi"></param>
        /// <param name="strKey"></param>
        /// <param name="strValue"></param>
        public static void SetValue(FileInfo fi, string strKey, string strValue)
        {
            string strJson = FileService.ReadAll(fi.FullName);
            SetValue(fi.FullName, strJson, strKey, strValue);
        }
        /// <summary>
        /// 读取文件路径，写入Json内容
        /// </summary>
        /// <param name="strJsonPath"></param>
        /// <param name="strJson"></param>
        /// <param name="strKey"></param>
        /// <param name="strValue"></param>
        public static void SetValue(string strJsonPath, string strJson, string strKey, string strValue)
        {
            JObject jo = (JObject)JsonConvert.DeserializeObject(strJson);
            jo[strKey] = strValue;
            string output = JsonConvert.SerializeObject(jo, Formatting.Indented);
            FileService.WriteAll(strJsonPath, output);
        }
        /// <summary>
        /// 读取文件路径，获取Json内容
        /// </summary>
        /// <param name="strFilePath"></param>
        /// <returns></returns>
        public static string GetAllContent(string strFilePath)
        {
            return FileService.ReadAll(strFilePath);
        }
        /// <summary>
        /// 读取文件路径，获取Json内容
        /// </summary>
        /// <param name="fi"></param>
        /// <returns></returns>
        public static string GetAllContent(FileInfo fi)
        {
            return GetAllContent(fi.FullName);
        }
        /// <summary>
        /// 读取文件路径，从Json字符串的对象中获取Json字符串
        /// </summary>
        /// <param name="fi"></param>
        /// <param name="strKey"></param>
        /// <returns></returns>
        public static string GetJson(FileInfo fi, string strKey)
        {
            string strJson = FileService.ReadAll(fi.FullName);
            return GetJson(strJson, strKey);
        }
        /// <summary>
        /// 读取文件内容，从Json字符串的对象中获取Json字符串
        /// </summary>
        /// <param name="strJson"></param>
        /// <param name="strKey"></param>
        /// <returns></returns>
        public static string GetJson(string strJson, string strKey)
        {
            JObject jo = (JObject)JsonConvert.DeserializeObject(strJson);
            return jo[strKey].ToJson();
        }
        /// <summary>
        /// 读取文件路径，从Json字符串的对象中获取值
        /// </summary>
        /// <param name="fi"></param>
        /// <param name="strKey"></param>
        /// <returns></returns>
        public static string GetValue(FileInfo fi, string strKey)
        {
            string strJson = FileService.ReadAll(fi.FullName);
            return GetValue(strJson, strKey);
        }
        /// <summary>
        /// 读取文件内容，从Json字符串的对象中获取值
        /// </summary>
        /// <param name="strJson"></param>
        /// <param name="strKey"></param>
        /// <returns></returns>
        public static string GetValue(string strJson, string strKey)
        {
            JObject jo = (JObject)JsonConvert.DeserializeObject(strJson);
            return jo[strKey].ToString();
        }
        /// <summary>
        /// 读取文件路径，从Json字符串的数组中获取值
        /// </summary>
        /// <param name="fi"></param>
        /// <param name="index"></param>
        /// <param name="strKey"></param>
        /// <returns></returns>
        public static string GetValue(FileInfo fi, int index, string strKey)
        {
            string strJson = FileService.ReadAll(fi.FullName);
            return GetValue(strJson, index, strKey);
        }
        /// <summary>
        /// 读取文件内容，从Json字符串的数组中获取值
        /// </summary>
        /// <param name="strJson"></param>
        /// <param name="index"></param>
        /// <param name="strKey"></param>
        /// <returns></returns>
        public static string GetValue(string strJson, int index, string strKey)
        {
            JArray ja = (JArray)JsonConvert.DeserializeObject(strJson);
            return ja[index][strKey]?.ToJson();
        }
    }
}
