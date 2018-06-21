using System;
using System.IO;
using System.Text;

namespace SimpleIOConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var folderPath = @"E:\temp\SimpleIOConsole\Output";
                var fileName = $"{DateTime.Now.ToString("yyyyMMddHHmmss")}.txt";
                var outputDirectoryInfo = new DirectoryInfo(folderPath);
                var outputFileInfo = new FileInfo(Path.Combine(folderPath, fileName));

                if (outputDirectoryInfo.Exists == false)
                {
                    outputDirectoryInfo.Create();
                }

                var datumString = @"Hello World!!";
                var datum = Encoding.Default.GetBytes(datumString);

                using (var stream = new FileStream(
                                        outputFileInfo.FullName, FileMode.CreateNew,
                                        FileAccess.ReadWrite, FileShare.ReadWrite))
                {
                    Console.WriteLine($"寫入檔案{outputFileInfo.FullName}開始...");
                    stream.Write(datum, 0, datum.Length);
                    Console.WriteLine($"寫入檔案{outputFileInfo.FullName}完成");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                Console.ReadLine();
            }
        }
    }
}
