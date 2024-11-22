using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Alchemy.Core.Extension
{
    public static class HttpContextExtension
    {
        /// <summary>
        /// 获取请求的Referer
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static string GetReferer(this HttpContext context)
        {
            if (context.Request.Headers.ContainsKey("Referer"))
                return context.Request.Headers["Referer"].ToString();
            else
                return string.Empty;
        }
        /// <summary>
        /// 判断是否本地请求
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static bool IsLocalRequest(this HttpContext context)
        {
            return context.GetFromIp().Equals("127.0.0.1");
        }
        /// <summary>
        /// 获取接口路由
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static string GetRoute(this HttpContext context)
        {
            return context.Request.Path;
        }
        /// <summary>
        /// 获取请求方法
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static string GetMethod(this HttpContext context)
        {
            return context.Request.Method;
        }
        /// <summary>
        /// 获取请求URL
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static string GetRequestUrl(this HttpContext context)
        {
            return $"{context.Request.Scheme}://{context.Request?.Host}{context.Request?.Path}{context.Request?.QueryString}";
        }
        /// <summary>
        /// 获取Authorization
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static string GetAuthorization(this HttpContext context)
        {
            return context.Request.Headers["Authorization"].ToString();
        }
        /// <summary>
        /// 判断是否包含Authorization
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static bool ContainsAuthorization(this HttpContext context)
        {
            return context.Request.Headers.ContainsKey("Authorization");
        }
        /// <summary>
        /// 获取UA
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static string GetUserAgent(this HttpContext context)
        {
            return context.Request.Headers["User-Agent"].ToString();
        }
        /// <summary>
        /// 获取请求者IP
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static string GetFromIp(this HttpContext context)
        {
            if (context.Connection.RemoteIpAddress.IsNull())
                return string.Empty;
            else
                return context.Connection.RemoteIpAddress.ToString().Replace("::ffff:", "");
        }
        /// <summary>
        /// 获取请求者端口
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static int GetFromPort(this HttpContext context)
        {
            return context.Connection.RemotePort;
        }
        /// <summary>
        /// 根据键获取请求的查询参数的值
        /// </summary>
        /// <param name="context"></param>
        /// <param name="strKey"></param>
        /// <returns></returns>
        public static string? GetQueryValue(this HttpContext context, string strKey)
        {
            return context.Request.Query[strKey];
        }
        /// <summary>
        /// 获取请求的参数json，不分请求方式
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static async Task<string> GetParamJson(this HttpContext context)
        {
            string strParamJson = string.Empty;
            string strMethod = context.GetMethod();
            switch (strMethod)
            {
                case "GET":
                case "DELETE":
                    strParamJson = context.GetQueryJson();
                    break;
                case "PUT":
                case "POST":
                    strParamJson = await context.GetBodyJson();
                    break;
            }
            return strParamJson;
        }
        /// <summary>
        /// 获取请求的查询参数json
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static string GetQueryJson(this HttpContext context)
        {
            JObject jo = new JObject();
            foreach (string strKey in context.Request.Query.Keys)
            {
                jo.Add(strKey, context.Request.Query[strKey].ToString());
            }
            return jo.ToJson();
        }
        /// <summary>
        /// 获取请求的body参数json
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static async Task<string> GetBodyJson(this HttpContext context)
        {
            StreamReader stream = new StreamReader(context.Request.Body);
            string strRawJson = await stream.ReadToEndAsync();
            return JsonConvert.DeserializeObject(strRawJson).ToJson();
        }
    }
}
