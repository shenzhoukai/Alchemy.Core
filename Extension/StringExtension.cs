using Alchemy.Core.Service;
using System.Text.RegularExpressions;

namespace Alchemy.Core.Extension
{
    public static class StringExtension
    {
        /// <summary>
        /// 字符串转Double
        /// </summary>
        /// <param name="strInput"></param>
        /// <returns></returns>
        public static double ToDouble(this string? strInput)
        {
            if (strInput.IsNull())
                return -1;
            bool result = double.TryParse(strInput, out double number);
            if (result)
                return number;
            else
                return -1;
        }
        /// <summary>
        /// 字符串转Long
        /// </summary>
        /// <param name="strInput"></param>
        /// <returns></returns>
        public static long ToLong(this string? strInput)
        {
            if (strInput.IsNull())
                return -1;
            bool result = long.TryParse(strInput, out long number);
            if (result)
                return number;
            else
                return -1;
        }
        /// <summary>
        /// 字符串转Int
        /// </summary>
        /// <param name="strInput"></param>
        /// <returns></returns>
        public static int ToInt(this string? strInput)
        {
            if (strInput.IsNull())
                return -1;
            bool result = int.TryParse(strInput, out int number);
            if (result)
                return number;
            else
                return -1;
        }
        /// <summary>
        /// 字符串转Float
        /// </summary>
        /// <param name="strInput"></param>
        /// <returns></returns>
        public static float ToFloat(this string? strInput)
        {
            if (strInput.IsNull())
                return -1;
            bool result = float.TryParse(strInput, out float number);
            if (result)
                return number;
            else
                return -1;
        }
        /// <summary>
        /// 字符串转布尔值
        /// </summary>
        /// <param name="strInput"></param>
        /// <returns></returns>
        public static bool ToBool(this string? strInput)
        {
            if (strInput.IsNull())
                return false;
            return bool.Parse(strInput);
        }
        /// <summary>
        /// 字符串转字节
        /// </summary>
        /// <param name="strInput"></param>
        /// <returns></returns>
        public static byte ToByte(this string strInput)
        {
            return Convert.ToByte(strInput);
        }
        /// <summary>
        /// 字符串转日期格式
        /// </summary>
        /// <param name="strDt"></param>
        /// <returns></returns>
        public static DateTime ToDt(this string strDt)
        {
            strDt = strDt.Replace("-0", "/");
            strDt = strDt.Replace("-", "/");
            return DateTime.Parse(strDt);
        }
        /// <summary>
        /// 字符串日期转时间戳
        /// </summary>
        /// <param name="strDateTime"></param>
        /// <returns></returns>
        public static long ToTimeStamp(this string strDateTime)
        {
            long timeStamp = 946656000;
            try
            {
                timeStamp = (Convert.ToDateTime(strDateTime).Ticks - TimeZoneInfo.ConvertTimeFromUtc(new DateTime(1970, 1, 1), TimeZoneInfo.Local).Ticks) / 10000000;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return timeStamp;
        }
        /// <summary>
        /// 字符串是否为空
        /// </summary>
        /// <param name="strParam"></param>
        /// <returns></returns>
        public static bool IsNull(this string? strParam)
        {
            return string.IsNullOrEmpty(strParam);
        }
        public static bool IsNotNull(this string? strParam)
        {
            return !string.IsNullOrEmpty(strParam);
        }
        /// <summary>
        /// 判断是否合规日期时间字符串
        /// </summary>
        /// <param name="strParam"></param>
        /// <returns></returns>
        public static bool IsDateTime(this string strParam)
        {
            if (strParam.IsNull())
                return false;
            return RegexService.IsMatch(strParam, @"^[1-9]\d{3}-(0[1-9]|1[0-2])-(0[1-9]|[1-2][0-9]|3[0-1])\s+(20|21|22|23|[0-1]\d):[0-5]\d:[0-5]\d$");
        }
        /// <summary>
        /// 判断是否合规日期字符串
        /// </summary>
        /// <param name="strParam"></param>
        /// <returns></returns>
        public static bool IsDate(this string strParam)
        {
            if (strParam.IsNull())
                return false;
            return RegexService.IsMatch(strParam, @"^((([0-9]{3}[1-9]|[0-9]{2}[1-9][0-9]{1}|[0-9]{1}[1-9][0-9]{2}|[1-9][0-9]{3})-(((0[13578]|1[02])-(0[1-9]|[12][0-9]|3[01]))|((0[469]|11)-(0[1-9]|[12][0-9]|30))|(02-(0[1-9]|[1][0-9]|2[0-8]))))|((([0-9]{2})(0[48]|[2468][048]|[13579][26])|((0[48]|[2468][048]|[3579][26])00))-02-29))$");
        }
        /// <summary>
        /// 判断是否合规IP地址或域名
        /// </summary>
        /// <param name="strParam"></param>
        /// <returns></returns>
        public static bool IsIPorDomain(this string strParam)
        {
            if (strParam.IsNull())
                return false;
            bool value = strParam.IsIPv4();
            if (!value)
            {
                if (strParam.Contains("."))
                {
                    value = true;
                }
            }
            return value;
        }
        /// <summary>
        /// 检测是否IP地址
        /// </summary>
        /// <param name="strIP"></param>
        /// <returns></returns>
        public static bool IsIPv4(this string strIP)
        {
            if (strIP.IsNull())
                return false;
            if (strIP.Length < 7 || strIP.Length > 15)
                return false;
            string pattern = @"^(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])$";
            return RegexService.IsMatch(strIP, pattern);
        }
        /// <summary>
        /// 检测是否手机号
        /// </summary>
        /// <param name="strMobilePhone"></param>
        /// <returns></returns>
        public static bool IsMobilePhone(this string strMobilePhone)
        {
            string pattern = @"^1[3-9]\d{9}$";
            return RegexService.IsMatch(strMobilePhone, pattern);
        }
        /// <summary>
        /// 判断是否版本号
        /// </summary>
        /// <param name="strParam"></param>
        /// <returns></returns>
        public static bool IsVersion(this string strParam)
        {
            bool value = false;
            if (strParam.Contains("."))
            {
                string[] arrVer = strParam.Split('.');
                if (arrVer.Length > 1)
                {
                    value = true;
                    foreach (string strVerNum in arrVer)
                    {
                        value = value & int.TryParse(strVerNum, out int verNum);
                    }
                }
            }
            return value;
        }
    }
}
