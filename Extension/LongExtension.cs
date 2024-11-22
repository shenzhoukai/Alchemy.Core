namespace Alchemy.Core.Extension
{
    public static class LongExtension
    {
        /// <summary>
        /// 时间戳转DateTime
        /// </summary>
        /// <param name="timeStamp"></param>
        /// <returns></returns>
        public static DateTime ToDateTime(this long timeStamp)
        {
            DateTime dt = new DateTime(2000, 1, 1, 0, 0, 0);
            try
            {
                dt = DateTimeOffset.FromUnixTimeSeconds(timeStamp).LocalDateTime;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return dt;
        }
        /// <summary>
        /// 时间戳转DateTimeUtc
        /// </summary>
        /// <param name="timeStamp"></param>
        /// <returns></returns>
        public static DateTime ToDateTimeUtc(this long timeStamp)
        {
            DateTime dt = new DateTime(2000, 1, 1, 0, 0, 0);
            try
            {
                dt = DateTimeOffset.FromUnixTimeSeconds(timeStamp).DateTime;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return dt;
        }
    }
}
