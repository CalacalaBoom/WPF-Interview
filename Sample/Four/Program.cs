
using System;
using System.Diagnostics;

namespace Four
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //读取网卡信息
            var ipresult = Run();
            Console.WriteLine(ipresult);

            //使用默认浏览器打开百度
            OpenBaidu();

            //打开资源管理器并指向某个路径
            OpenDownloadPath();

            //用默认方式打开某个应用，即直接打开某个exe（两种方法）
            //直接调用打开文件
            Process.Start(@"D:\dnSpy\x64\dnSpy-net-win64\dnSpy.exe");
            //用某种应用打开某个文件
            Process.Start("D:\\Microsoft VS Code\\Code.exe", "C:\\Users\\HEYii\\source\\repos\\WPF-Interview\\README.md");
        }

        private static void OpenDownloadPath()
        {
            System.Diagnostics.ProcessStartInfo processStartInfo = new System.Diagnostics.ProcessStartInfo();

            processStartInfo.FileName = "explorer.exe";  //资源管理器

            processStartInfo.Arguments = @"C:\Users\HEYii\Downloads";

            System.Diagnostics.Process.Start(processStartInfo);

            Console.ReadLine();
        }

        private static void OpenBaidu()
        {
            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = "www.baidu.com",
                    UseShellExecute = true // 必须设置为 true 才能使用系统默认浏览器
                });
            }
            catch (System.Exception ex)
            {
                // 处理异常
                Console.WriteLine("无法打开浏览器: " + ex.Message);
            }
        }

        private static string Run()
        {
            using (Process process = new Process()) // 确保资源释放
            {
                process.StartInfo.CreateNoWindow = true; // 不显示窗口
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.FileName = "cmd.exe"; // 设置程序名
                process.StartInfo.RedirectStandardInput = true; // 重定向标准输入
                process.StartInfo.RedirectStandardOutput = true; // 重定向标准输出
                process.StartInfo.RedirectStandardError = true; // 重定向标准错误输出

                process.Start(); // 启动进程

                using (StreamWriter sw = process.StandardInput)
                {
                    if (sw.BaseStream.CanWrite)
                    {
                        sw.WriteLine("ipconfig"); // 执行命令
                        sw.WriteLine("exit"); // 退出 cmd
                    }
                }

                string output = process.StandardOutput.ReadToEnd(); // 读取标准输出
                process.WaitForExit(); // 等待进程退出

                return output; // 返回输出
            }
        }
    }
}
