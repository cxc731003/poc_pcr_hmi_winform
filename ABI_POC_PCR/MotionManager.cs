using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ABI_POC_PCR.SerialComm;



namespace ABI_POC_PCR
{
    enum SELECTEDMOTOR
    {
        NEGATIVE_PRESSURE = 0,
        SYRINGE,
        PUMPING,
        MAGNET_LOAD,
        NEEDLE
    }
    public class MotionManager
    {
        PcrProtocol rs232 = PcrProtocol.GetInstance();
        public void moveSM(int selectedMotor, int direction, int pulseCount, int PulsePeriod)
        {
            switch(selectedMotor)
            {
                case (int)(SELECTEDMOTOR.NEGATIVE_PRESSURE):
                    selectedMotor = 1;
                    break;
                case (int)(SELECTEDMOTOR.SYRINGE):
                    selectedMotor = 2;
                    break;
                case (int)(SELECTEDMOTOR.PUMPING):
                    selectedMotor = 3;
                    break;
                case (int)(SELECTEDMOTOR.MAGNET_LOAD):
                    selectedMotor = 4;
                    break;
                case (int)(SELECTEDMOTOR.NEEDLE):
                    selectedMotor = 5;
                    break;
            }

            StringBuilder sb = new StringBuilder();
            sb.Append(":SM");
            sb.Append(selectedMotor.ToString()+"1");
            sb.Append(string.Format("{0:0000}{1:0000}", pulseCount, PulsePeriod));

            string command = sb.ToString();
            //return command;
            Console.WriteLine(command);
            rs232.SendLine(command);
        }

    }

    
}
