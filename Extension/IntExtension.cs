using System.Numerics;

namespace Alchemy.Core.Extension
{
    public static class IntExtension
    {
        /// <summary>
        /// 整出取余
        /// </summary>
        /// <param name="timerCount"></param>
        /// <param name="timerInterval"></param>
        /// <returns></returns>
        public static bool RemainderSuccess(this int timerCount, int timerInterval)
        {
            return BigInteger.Remainder(new BigInteger(timerCount), new BigInteger(timerInterval)).Equals(0);
        }
        /// <summary>
        /// 判断是否合规端口
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public static bool IsPort(this int param)
        {
            if (param >= 1 && param <= 65535)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 判断是否合规正整数和零
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public static bool IsIntNotNegative(this int param)
        {
            if (param >= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 判断是否合规月份数
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public static bool IsMonth(this int param)
        {
            if (param >= 1 && param <= 12)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 判断是否合规正整数
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public static bool IsIntPositive(this int param)
        {
            if (param > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
