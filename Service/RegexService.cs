﻿using System.Text.RegularExpressions;
namespace Alchemy.Core.Service
{
    public class RegexService
    {
        /// <summary>
        /// 判断正则表达式
        /// </summary>
        /// <param name="strRaw"></param>
        /// <param name="strFormat"></param>
        /// <returns></returns>
        public static bool IsMatch(string strRaw, string strFormat)
        {
            Regex regex = new Regex(strFormat, RegexOptions.None);
            return regex.IsMatch(strRaw);
        }
    }
}
