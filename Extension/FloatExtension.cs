namespace Alchemy.Core.Extension
{
    public static class FloatExtension
    {
        public static string ToDecimalCount(this float value, int count = 0)
        {
            string strFormat = "0";
            if (count < 0)
                strFormat = "0";
            else
            {
                strFormat += ".";
                for (int i = 0; i < count; i++)
                    strFormat += "0";
            }
            return value.ToString(strFormat);
        }
    }
}
