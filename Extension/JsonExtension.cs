using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
namespace Alchemy.Core.Extension
{
    public static class JsonExtension
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public static string GetValue(this JToken token)
        {
            string result = "null";
            switch (token.Type)
            {
                case JTokenType.Null:
                    result = "null";
                    break;
                case JTokenType.Boolean:
                    result = $"{token}".ToLower();
                    break;
                case JTokenType.String:
                    result = $"\"{token}\"";
                    break;
                default:
                    result = $"{token}";
                    break;
            }
            return result;
        }
        /// <summary>
        /// Json字符串转换为实体对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="input"></param>
        /// <returns></returns>
        public static T? FromJson<T>(this string input)
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(input);
            }
            catch
            {
                return default;
            }
        }
        /// <summary>
        /// 实体对象转换为Json字符串
        /// </summary>
        /// <param name="obj">对象</param>
        /// <returns>Json字符串</returns>
        public static string ToJson(this object? obj)
        {
            if (obj.IsNull())
                return string.Empty;
            return JsonConvert.SerializeObject(obj);
        }
        /// <summary>
        /// 实体对象转换为Json格式化字符串
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ToPrettyJson(this object obj)
        {
            if (obj.IsNull())
                return string.Empty;
            return JsonConvert.SerializeObject(obj, Formatting.Indented);
        }
        /// <summary>
        /// 对象转安全Json字符串
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ToSafeJson(this object obj)
        {
            if (obj.IsNull())
                return string.Empty;
            return JsonConvert.SerializeObject(obj).Replace("\"", "\\\"");
        }
    }
}
