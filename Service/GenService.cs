namespace Alchemy.Core.Service
{
    public class GenService
    {
        public static string GenNumberCode(int degit)
        {
            if (degit > 1)
            {
                Random random = new Random();
                string code = random.Next(10 ^ (degit - 1), 10 ^ degit).ToString();
                return code.PadLeft(degit, '0');
            }
            else
                return "0";
        }
    }
}
