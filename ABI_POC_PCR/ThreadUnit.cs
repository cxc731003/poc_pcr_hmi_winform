using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.IO;
namespace SmartFMS
{
	public static class TThreadUnit
	{
		const int MAX_THRD_PROC   =    3;
							  	   
		const int TP_1            =     0;
		const int TP_2            =     1;
		const int TP_3            =     2;

		const int TP_INTERVAL1    =     2;
		const int TP_INTERVAL2    =     2;
		const int TP_INTERVAL3    =     5;


		static IntPtr[]           ThreadHandle;
		static bool  []           ThreadEnable;
		static long  []           dwStrtTime  ;
		static long  []           dwScanTime  ;
		static long  []           dwTimerId   ;
		static int   []           iTimerId    ;

		static Thread[]           Thread      ;

		static TThreadUnit()
		{							        
			ThreadHandle  = new  IntPtr     [MAX_THRD_PROC    ];
			ThreadEnable  = new  bool       [MAX_THRD_PROC    ];
			dwStrtTime    = new  long       [MAX_THRD_PROC * 2];
			dwScanTime    = new  long       [MAX_THRD_PROC * 2];
			dwTimerId     = new  long       [MAX_THRD_PROC    ];
			iTimerId      = new  int        [MAX_THRD_PROC    ];
			Thread        = new  Thread     [MAX_THRD_PROC    ];
		}
		public static void StartThread()
		{
			//Thread #1
			ThreadEnable[TP_1 ] = true;
			Thread[TP_1] = new Thread(ThrdFunc1);
			Thread[TP_1].Priority = ThreadPriority.Normal;
			Thread[TP_1].Start();

			//Thread #2
			ThreadEnable[TP_2 ] = true;
			Thread[TP_2] = new Thread(ThrdFunc2);
			Thread[TP_2].Priority = ThreadPriority.Normal;
			Thread[TP_2].Start();

			//Thread #3
			ThreadEnable[TP_3 ] = true;
			Thread[TP_3] = new Thread(ThrdFunc3);
			Thread[TP_3].Priority = ThreadPriority.Normal;
			Thread[TP_3].Start();
		}
		public static void EndThread()
		{
			//Clear EnableFlag.
			for (int n = TP_1 ; n < MAX_THRD_PROC ; n++) ThreadEnable[n] = false;

			//Thread #1
			do {
				Thread[TP_1].Join(500);
				Application.DoEvents();
				}
			while(Thread[TP_1].IsAlive);

			//Thread #2
			do {
				Thread[TP_2].Join(500);
				Application.DoEvents();
				}
			while(Thread[TP_2].IsAlive);

			//Thread #3
			do {
				try
				{
					Thread[TP_3].Join(500);
					Application.DoEvents();
				}
				catch(Exception ex)
				{
				}
			}
			while(Thread[TP_3].IsAlive);
		}
		private static void ThrdFunc1()
		{
			long Crnt;
		
			try
			{
				while (ThreadEnable[TP_1]) {
					//Update.
					//Main.WM.Update();
					System.Threading.Thread.Sleep(500);

					//(101014) - Primer ;
					Application.DoEvents();
					//Cal. Scan Time.
					Crnt             = Environment.TickCount  ;
					dwScanTime[TP_1] = Crnt - dwStrtTime[TP_1];
					dwStrtTime[TP_1] = Crnt;
					}
			}
			catch (Exception err)
			{
				//Var.
				string sPath    ;
				string sFileName;
				StreamWriter ExceptionLog;

				//Set Path.
				sPath = Path.Combine(Environment.CurrentDirectory , "Exception");
				if (!Directory.Exists(sPath)) Directory.CreateDirectory(sPath);
				sFileName = Path.Combine(sPath , "ThreadException1.Log");
				FileStream fStream = new FileStream(sFileName, FileMode.OpenOrCreate);
				fStream.Seek(0, SeekOrigin.End);
				ExceptionLog = new StreamWriter(fStream);

				//Write Exception Log.
				ExceptionLog.WriteLine(err.StackTrace);
				ExceptionLog.Close();
			}
		}
		private static void ThrdFunc2()
		{
			long Crnt;
		
			try
			{
				while (ThreadEnable[TP_2]) {
					//
					System.Threading.Thread.Sleep(1);
				
					//(101014) - Primer ;
					Application.DoEvents();
					//Cal. Scan Time.
					Crnt             = Environment.TickCount  ;
					dwScanTime[TP_2] = Crnt - dwStrtTime[TP_2];
					dwStrtTime[TP_2] = Crnt;
					}
			}
			catch (Exception err)
			{
				//Var.
				string sPath    ;
				string sFileName;
				StreamWriter ExceptionLog;
			

				//Set Path.
				sPath = Path.Combine(Environment.CurrentDirectory , "Exception");
				if (!Directory.Exists(sPath)) Directory.CreateDirectory(sPath);
				sFileName = Path.Combine(sPath , "ThreadException2.Log");
				FileStream fStream = new FileStream(sFileName, FileMode.OpenOrCreate);
				fStream.Seek(0, SeekOrigin.End);
				ExceptionLog = new StreamWriter(fStream);

				//Write Exception Log.
				ExceptionLog.WriteLine(err.Message);
				ExceptionLog.Close();
			}
		}
		private static void ThrdFunc3()
		{
			long Crnt;
		
			try
			{
				while (ThreadEnable[TP_3]) {
					//

					System.Threading.Thread.Sleep(1);

					//(101014) - Primer ;
					Application.DoEvents();
					//Cal. Scan Time.
					Crnt             = Environment.TickCount  ;
					dwScanTime[TP_2] = Crnt - dwStrtTime[TP_2];
					dwStrtTime[TP_2] = Crnt;
					}
			}
			catch (Exception err)
			{
				//Var.
				string sPath    ;
				string sFileName;
				StreamWriter ExceptionLog;
			

				//Set Path.
				sPath = Path.Combine(Environment.CurrentDirectory , "Exception");
				if (!Directory.Exists(sPath)) Directory.CreateDirectory(sPath);
				sFileName = Path.Combine(sPath , "ThreadException3.Log");
				FileStream fStream = new FileStream(sFileName, FileMode.OpenOrCreate);
				fStream.Seek(0, SeekOrigin.End);
				ExceptionLog = new StreamWriter(fStream);

				//Write Exception Log.
				ExceptionLog.WriteLine(err.Message);
				ExceptionLog.Close();
			}
		}
	}
}
