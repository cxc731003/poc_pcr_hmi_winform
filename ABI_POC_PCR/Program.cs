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

            LogIn LogIn = new LogIn();
            LogIn.Show();
            //LogIn.DialogResult = DialogResult.OK;// 주석 처리 필요
            while (LogIn.DialogResult != DialogResult.OK)
            {
                Application.DoEvents();
            }

            LogIn.Close();
            try
            {
                Application.Run(new MainFrm());
            }
            catch (Exception ex)
            {
                //Var.
                string sPath;
                string sFileName;
                StreamWriter ExceptionLog;

                //Set Path.
                sPath = Path.Combine(Environment.CurrentDirectory, "Exception");
                if (!Directory.Exists(sPath)) Directory.CreateDirectory(sPath);
                sFileName = Path.Combine(sPath, "Program.Log");
                FileStream fStream = new FileStream(sFileName, FileMode.OpenOrCreate);
                fStream.Seek(0, SeekOrigin.End);
                ExceptionLog = new StreamWriter(fStream);

                //Write Exception Log.
                ExceptionLog.WriteLine(DateTime.Now.ToLongDateString() + "/" + ex.StackTrace);
                ExceptionLog.Close();

                MessageBox.Show(ex.StackTrace);

            }
            finally
            {

            }
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

        public void MakeNewFileForMonitor()
        {
            //filePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            filePath = Application.StartupPath + @"\log";
            string temp = DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss");
            filePath += "/Pcr " + temp + "_M.txt";
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
