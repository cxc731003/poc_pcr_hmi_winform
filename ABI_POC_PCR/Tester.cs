using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABI_POC_PCR
{

    enum TARGET_SELECTION{
        TB = 0,
        COVID,
        FLU,
    }


    public class Tester
    {
        public DateTime start_time { get; set; }
        public DateTime end_time { get; set; }
        public string Tablename { get; set; }
        public string InspectorName { get; set; }
        public string InspectorID { get; set; }

        public string PatientID { get; set; }
        public string CartridgeID { get; set; }
        public string SampleID { get; set; }

        bool[] tubeTestResult;

        int targetSelection;

        public string TuberCulosis { get; set; }
        public string NonTuberCulousMycobacteria { get; set; }
        public string rifampin { get; set; }

        public Tester()
        {
            InitializeTesterVariable();
        }

        public void InitializeTesterVariable()
        {
            start_time = DateTime.Now;
            end_time = DateTime.Now;

            Tablename = "";

            InspectorName = "";
            InspectorID = "";

            PatientID = "";
            CartridgeID = "";
            SampleID = "";
            
            //Initialize tube IC testResult  
            for(int i = 0; i < 7; i++)
            {
                tubeTestResult[i] = false;
            }
            
            if(targetSelection == (int)TARGET_SELECTION.TB)
            {
                TuberCulosis = "";
                NonTuberCulousMycobacteria = "";
                rifampin = "";
            }
            else if(targetSelection == (int)TARGET_SELECTION.COVID)
            {
                
            }
            else if(targetSelection == (int)TARGET_SELECTION.FLU)
            {

            }


        }
    }
}




