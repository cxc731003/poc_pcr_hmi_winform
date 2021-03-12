using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABI_POC_PCR
{
    enum TUBE_INDEX
    {
        FAM = 0,
        HEX,
        ROX,
        CY5
    }

    enum UI_MODE
    {
        TESTER_UI = 0,
        ENGINEER_UI
    }
    
    public static class Global
    {
        public static int[,] opticValArray = new int[28, 4];
        public static int Tube_Cnt = 4;


        
    }
}
