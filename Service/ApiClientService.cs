using Newtonsoft.Json.Linq;
using RestSharp;
using Alchemy.Core.Extension;
namespace Alchemy.Core.Service
{
    public static class ApiClientService
    {
        /// <summary>
        /// 发起API请求
        /// </summary>
        /// <param name="reqMethod"></param>
        /// <param name="strBaseUrl"></param>
        /// <param name="strRouteUrl"></param>
        /// <param name="queryParam"></param>
        /// <param name="body"></param>
        /// <param name="headerList"></param>
        /// <param name="timeOut"></param>
        /// <returns></returns>
        public static ApiResponse Request(Method reqMethod, string strBaseUrl, string strRouteUrl = null, Dictionary<string, string> queryParam = null, object body = null, Dictionary<string, string> headerList = null, string strContentType = "application/json", int timeOut = 3)
        {
            ApiResponse resp = new ApiResponse()
            {
                StatusCode = -1,
                Content = string.Empty
            };
            RestClient client = new RestClient(strBaseUrl);
            if (queryParam is not null)
            {
                if (queryParam.Count > 0)
                    strRouteUrl += "?";
                int index = 0;
                foreach (KeyValuePair<string, string> kvp in queryParam)
                {
                    strRouteUrl += $"{System.Web.HttpUtility.UrlEncode(kvp.Key)}={System.Web.HttpUtility.UrlEncode(kvp.Value)}";
                    if (index < queryParam.Count - 1)
                        strRouteUrl += "&";
                    index++;
                }
            }
            RestRequest request = new RestRequest(strRouteUrl, reqMethod);
            if (headerList is not null)
            {
                foreach (KeyValuePair<string, string> kvp in headerList)
                {
                    request.AddHeader(kvp.Key, kvp.Value);
                }
            }
            request.Timeout = TimeSpan.FromSeconds(timeOut);
            if (!body.IsNull())
            {
                if(body is JObject && strContentType.StartsWith("application/json"))
                {
                    request.AddHeader("Content-Type", strContentType);
                    request.RequestFormat = DataFormat.Json;
                    request.AddJsonBody(body.ToJson());
                }
                if(body is JObject && strContentType.StartsWith("multipart/form-data"))
                {
                    JObject jo = (JObject)body;
                    foreach (JProperty? jp in jo.Properties())
                    {
                        if (jp.IsNull())
                            continue;
                        if (jp.Name.Equals("size"))
                            request.AddParameter(jp.Name, jp.Value.ToString().ToLong());
                        if (!jp.Name.Equals("file"))
                            request.AddParameter(jp.Name, jp.Value.ToString());
                        else
                            request.AddFile("file", jp.Value.ToString());
                    }
                }
            }
            string strResp = string.Empty;
            try
            {
                RestResponse<ApiResponse> response = client.Execute<ApiResponse>(request);
                if (response is not null)
                {
                    resp.StatusCode = (int)response.StatusCode;
                    resp.Content = response.Content;
                }
            }
            catch (Exception ex)
            {
                resp.Content = ex.Message;
            }
            return resp;
        }
    }
    public class ApiResponse
    {
        public int StatusCode { get; set; }
        public string Content { get; set; }
    }
}
