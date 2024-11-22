using System.Text;
namespace Alchemy.Core.Service
{
    public class FileService
    {
        //编码格式：去除BOM头的UTF8
        private static Encoding _enc = new UTF8Encoding(encoderShouldEmitUTF8Identifier: false);
        /// <summary>
        /// 读取文件内容
        /// </summary>
        /// <param name="strFilePath"></param>
        /// <returns></returns>
        public static string ReadAll(string strFilePath)
        {
            FileInfo fileInfo = new FileInfo(strFilePath);
            if (fileInfo.Exists)
                return File.ReadAllText(strFilePath, _enc);
            else
                return string.Empty;
        }
        /// <summary>
        /// 写入文件内容
        /// </summary>
        /// <param name="strFilePath"></param>
        /// <param name="strContent"></param>
        public static void WriteAll(string strFilePath, string strContent)
        {
            File.WriteAllText(strFilePath, strContent, _enc);
        }
    }
}
