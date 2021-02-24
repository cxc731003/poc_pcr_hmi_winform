using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


namespace ABI_POC_PCR
{
    class ThreadManager
    {
        
        public static void ThreadMgr()
        {
            Thread thread = new Thread(() => ThreadRun());
        }

        public static void ThreadRun()
        {
            Administrator admin = new Administrator();
            
            string currentTime = DateTime.Now.ToLongTimeString();
            string currentDate = DateTime.Now.ToShortDateString();

            admin.updateBaseData();
            admin.updateCycleData();
            admin.UpdateFinalData();



        }
        
        
    }
}
