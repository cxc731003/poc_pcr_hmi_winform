using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABI_POC_PCR
{
    public class Administrator
    {
        public string[] tube1;
        public string[] tube2;
        public string[] tube3;
        public string[] tube4;

        public string[,] baseData;
        public string[,] cycleData;
        public string[,] finalData;

        public Dictionary<string, List<double>> ch1DataDic, ch2DataDic, ch3DataDic, ch4DataDic;

        //Registration Infomation 
        private string Name { get; set; }
        private string ID { get; set; }
        private string Password { get; set; }
        private string Authorization {get; set;}
        
        public Administrator()
        {

        }

        private void initializeAdministrator()
        {
           tube1 = new string[28] { "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "" };
           tube2 = new string[28] { "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "" };
           tube3 = new string[28] { "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "" };
           tube4 = new string[28] { "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "" };
        }

        public void setRegistrationInfo()
        {
            Name = "";
            ID = "";
            Password = "";
            Authorization = "";
        }

        public string[,] updateBaseData()
        {
            for(int i = 0; i < 4; i++)
            {
                baseData[i, 0] = ""; //something need to insert 
            }
            return baseData;
        }

        public string[,] updateCycleData()
        {
            for( int i = 0; i < 4; i++ )
            {
                for (int j = 0; j < 26; j++)
                {
                    cycleData[i,j] = "";
                }
                
            }
            return cycleData;
        }

        public string[,] UpdateFinalData()
        {
            for(int i = 0; i < 4; i++)
            {
                finalData[i, 0] = "";
            }
            return finalData;
        }
    }
}
