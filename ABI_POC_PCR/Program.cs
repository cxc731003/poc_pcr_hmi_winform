using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace ABI_POC_PCR
{
    static class Program
    {
        /// <summary>
        /// 해당 애플리케이션의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LogIn());
            //Application.Run(new MainFrm());
        }
    }
    
   

    public class LogWriter
    {
        string filePath;

        SharedMemory sm = SharedMemory.GetInstance();

        public LogWriter()
        {

        }

        public void MakeNewFile()
        {
            //filePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            filePath = Application.StartupPath + @"\log";
            string temp = DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss");
            filePath += "/Pcr " + temp + ".txt";
            sm.current_Log_Name = "Pcr " + temp;
            //filePath = @"Pcr 2019-12-05 14-20-45.log";
            //Console.WriteLine("file name={0}", filePath);
            AppendLine("");
            AppendLine("==== start ====");
            AppendLine("");


            //try
            //{
            //    fileWriter = new StreamWriter(File.OpenWrite(filePath));
            //    Console.WriteLine("Wrtie log: {0}", filePath);
            //}
            //catch
            //{
            //    Console.WriteLine("log file open error");
            //}
        }

        public void CloseFile()
        {
            filePath = null;
        }

        public void AppendLine(string input)
        {
            try
            {
                using (StreamWriter wr = File.AppendText(filePath))
                {
                    try
                    {
                        wr.WriteLine(input);
                    }
                    catch
                    {
                        Console.WriteLine("log file append error");
                    }
                }
            }
            catch
            {
                Console.WriteLine("log file open error: {0}", filePath);
            }
        }

        public void Append(string input)
        {
            try
            {
                using (StreamWriter wr = File.AppendText(filePath))
                {
                    try
                    {
                        wr.Write(input);
                    }
                    catch
                    {
                        Console.WriteLine("log file append error: {0}", filePath);
                    }
                }
            }
            catch
            {
                Console.WriteLine("log file open error: {0}", filePath);
            }
        }
    }
}
