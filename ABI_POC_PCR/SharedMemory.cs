using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABI_POC_PCR
{
    public class SharedMemory
    {
        public int logLineCnt { get; set; }
        public string userID { get; set; } // Tester ID = login ID at first
        public string userPW { get; set; }  // Tester PW = login PW at first
        public string userName { get; set; } // Tester Name
        
        public string testName { get; set; } 
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        
        public string PatientID { get; set; }
        public string SampleID { get; set; }
        public string CartridgeID { get; set; }
        public string QualityControl { get; set; }
       


        public string userAccessibility { get; set; }
        public bool isLoginSucceeded { get; set; }


        public string currentLogFileName { get; set; }



        public int criticalThreshold { get; set; }
        public bool opticReceivedFlag { get; set; }
        public int measured_cnt { get; set; }

        public bool DataUpdateFlag { get; set; }
        public bool isFirstUpdate { get; set; }
        public bool ProcessEndFlag { get; set; }

        public int Routine_Cnt { get; set; }

        public int progressSecond { get; set; }//optic action 10~100%
        public int progressFirst { get; set; } //extraction 0~10%

        public int pre_routine_cnt { get; set; }
        public string current_Log_Name { get; set; }
        
        public int ui_mode { get; set; }

        public string DeviceStatus { get; set; }


        private static SharedMemory _instance = null;

        public static SharedMemory GetInstance()
        {
            if (_instance == null)
            {
                _instance = new SharedMemory();
            }
            return _instance;
        }
    }
}
