namespace Alchemy.Core.Extension
{
    public static class ObjectExtension
    {
        /// <summary>
        /// 判断对象是否为null
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool IsNull(this object? obj)
        {
            return obj is null;
        }
        public static bool IsNotNull(this object? obj)
        {
            return !obj.IsNull();
        }
    }
}
