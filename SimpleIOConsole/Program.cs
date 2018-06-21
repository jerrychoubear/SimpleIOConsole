using System;
using System.IO;
using System.Text;

namespace SimpleIOConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //NewMethod();

            try
            {
                var imageByteArray = File.ReadAllBytes(
                    @"E:\temp\854\PhysicalFolder_UploadFiles\009\009-20180620171122\未命名.png");

                const string filename = @"E:\abc.png";
                using (var stream = new FileStream(
                                        filename, FileMode.CreateNew,
                                        FileAccess.ReadWrite, FileShare.ReadWrite))
                {
                    Console.WriteLine($"寫入檔案{filename}開始...");
                    stream.Write(imageByteArray, 0, imageByteArray.Length);
                    Console.WriteLine($"寫入檔案{filename}完成");
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private static void NewMethod()
        {
            try
            {
                //var folderPath = @"E:\temp\SimpleIOConsole\Output";
                var folderPath = @"\\127.0.0.1\854\Test";
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
