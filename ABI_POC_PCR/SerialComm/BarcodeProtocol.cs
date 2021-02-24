using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Diagnostics;

namespace ABI_POC_PCR.SerialComm
{
    public struct SerialPortInfo2
    {
        public string Name;
        public bool IsOpened;
    }
    public class BarcodeProtocol
    {

        private static BarcodeProtocol _instance = null;

        public static BarcodeProtocol GetInstance()
        {
            if (_instance == null)
            {
                _instance = new BarcodeProtocol();
            }
            return _instance;
        }

        SerialPort ComPort1 = new SerialPort();
        SerialComm Serial;
        BarcodeRxProcess rxProc = new BarcodeRxProcess();

        public BarcodeProtocol()
        {
            Serial = new SerialComm(ComPort1);
            Serial.DelayedRxCallback += RxCallback;
        }

        /// <summary>
        /// 11520-8-1-none 설정으로 시리얼 포트 연결
        /// </summary>
        /// <param name="portName"></param>
        /// <returns></returns>
        public bool Connect(string portName)
        {
            return Connect(portName, 115200, 8, StopBits.One, Handshake.None);
        }

        public bool Connect(string portName, int baud = 115200, int dataBits = 8, StopBits stopBits = StopBits.One, Handshake handShake = Handshake.None)
        {
            bool rslt = false;

            if (ComPort1.IsOpen)
            {
                ComPort1.Close();
            }

            Debug.Print("Connect-> {0}", portName);
            ComPort1.PortName = portName;
            ComPort1.BaudRate = baud;
            ComPort1.DataBits = dataBits;
            ComPort1.StopBits = stopBits;
            ComPort1.Handshake = handShake;

            try
            {
                ComPort1.Open();
                rslt = true;
            }
            catch
            {
                Debug.Print("Connect> Port 열기 에러 발생");
            }

            return rslt;
        }

        public void Close()
        {
            if (ComPort1.IsOpen)
            {
                ComPort1.Close();
            }
        }

        public void Dispose()
        {
            ComPort1.Dispose();
        }

        public string[] GetPortNames()
        {
            List<string> portsNames = new List<string>();

            foreach (string comport in SerialPort.GetPortNames())
            {
                string tmpStr;
                ComPort1.PortName = comport;
                tmpStr = comport;

                try
                {
                    ComPort1.Open();
                }
                catch
                {
                    tmpStr += " (열림)";
                }
                finally
                {
                    ComPort1.Close();
                }

                portsNames.Add(tmpStr);
            }

            return portsNames.ToArray();
        }

        public SerialPortInfo2[] GetPortsInfo()
        {
            if (ComPort1.IsOpen)
            {
                new InvalidOperationException();
            }

            List<SerialPortInfo2> portsNames = new List<SerialPortInfo2>();

            foreach (string comport in SerialPort.GetPortNames())
            {
                SerialPortInfo2 tmp;
                ComPort1.PortName = comport;
                tmp.Name = comport;
                tmp.IsOpened = false;
                try
                {
                    ComPort1.Open();
                }
                catch
                {
                    tmp.IsOpened = true;
                }
                finally
                {
                    ComPort1.Close();
                }

                portsNames.Add(tmp);
            }

            return portsNames.ToArray();
        }


        //---------------------------------------------------------------------------------
        // communication
        //---------------------------------------------------------------------------------

        public void SendLine(string input)
        {
            //Serial.send(input);

            StringBuilder sb = new StringBuilder();

            foreach (char a in input)
            {
                sb.Append(a);
                sb.Append(' ');
            }
            sb.Append("\r \n");
            string text = sb.ToString();
            Serial.send(text);
        }

        public void SendBin(byte[] input)
        {
            Serial.send(input, input.Length);
        }

        public string ReceiveString()
        {
            //return Serial.Receive_String();
            byte[] read = Serial.Receive();
            byte[] str = rxProc.RxFindPacket(read);
            if (str != null)
            {
                return System.Text.Encoding.UTF8.GetString(str);
            }

            return string.Empty;
        }

        public string ReceiveString(out byte[] rawLog)
        {
            //return Serial.Receive_String();

            byte[] read = Serial.Receive();
            byte[] str = rxProc.RxFindPacket(read);

            rawLog = read;

            if (str != null)
            {
                return System.Text.Encoding.UTF8.GetString(str);
            }

            return string.Empty;
        }

        public event Action<object> ReceivedEvent;

        public bool IsConnect()
        {
            return ComPort1.IsOpen;
        }

        public event Action<object> ReceivedRacketEvent
        {
            add
            {
                rxProc.RevceivedPacket += value;
            }

            remove
            {
                rxProc.RevceivedPacket -= value;
            }
        }


        //---------------------------------------------------------------------------------
        // private
        //---------------------------------------------------------------------------------

        void RxCallback(object sender)
        {
            if (ReceivedEvent != null)
            {
                ReceivedEvent(this);
            }
        }

        List<byte> rx_bf = new List<byte>();
        //byte[] rx_msg;

        void parsingProtocol()
        {
            byte[] bf = Serial.Receive();

            rx_bf.AddRange(bf);

            //rx_bf.FindIndex()
        }
    }


    class BarcodeRxProcess
    {
        List<byte> lastData = new List<byte>();
        List<byte> makingPacket = new List<byte>();
        byte[] lastPacket;
        public event Action<object> RevceivedPacket;
        public Pcr_Packet rxPacket;

        // packet format: 0x3a [code] [sub] [len] [data0] [data1] [data2] [data3] 0x0d 0x0a

        int dataLen;
        int findingStep = 0;
        int dataIdx;
        // 0: 0x3a, 1: item code, 2: sub item code, 3: length, 4: data, 5: 0x0d, 6: 0x0a

        public byte[] RxFindPacket(byte[] input)
        {
            byte[] output = null;
            bool fail = false;

            if ((input == null) || (input.Length <= 0))
            {
                return null;
            }

            for (int i = 0; i < input.Length; i++)
            {
                if (findingStep == 0)
                {
                    if (input[i] == 0x3a)
                    {
                        findingStep = 1;
                        makingPacket.Clear();
                        makingPacket.Add(input[i]);
                    }
                    else
                    {
                        lastData.Add(input[i]);
                    }
                }
                else if (findingStep == 1)  // item code
                {
                    bool detect = false;
                    makingPacket.Add(input[i]);

                    if (input[i] == (byte)Optic_ItemCode.FC_OPT_BASE_VAL)
                    {
                        detect = true;
                    }
                    else if (input[i] == (byte)Optic_ItemCode.FC_OPT_VAL)
                    {
                        detect = true;
                    }
                    else if (input[i] == (byte)Optic_ItemCode.FC_TMP_VAL)
                    {
                        detect = true;
                    }

                    if (detect)
                    {
                        findingStep++;
                    }
                    else
                    {
                        fail = true;
                    }
                }
                else if (findingStep == 2)  // sub item code
                {
                    bool detect = false;
                    makingPacket.Add(input[i]);

                    if (Enum.IsDefined(typeof(Optic_SubItemCode), (int)input[i]))
                    {
                        detect = true;
                    }

                    if (detect)
                    {
                        findingStep++;
                        dataLen = 0;
                    }
                    else
                    {
                        fail = true;
                    }
                }
                else if (findingStep == 3)  // length
                {
                    makingPacket.Add(input[i]);
                    if (input[i] == 4)
                    {
                        findingStep++;
                        dataLen = 4;
                        dataIdx = 0;
                    }
                    else
                    {
                        fail = true;
                    }
                }
                else if (findingStep == 4)  // data
                {
                    makingPacket.Add(input[i]);
                    dataIdx++;

                    if (dataIdx == dataLen)
                    {
                        findingStep++;
                    }
                    else if (dataIdx > dataLen)
                    {
                        fail = true;
                    }
                }
                else if (findingStep == 5)  // 0x0d
                {
                    makingPacket.Add(input[i]);
                    if (input[i] == 0x0d)
                    {
                        findingStep++;
                    }
                    else
                    {
                        fail = true;
                    }
                }
                else if (findingStep == 6)  // 0x0a
                {
                    makingPacket.Add(input[i]);
                    if (input[i] == 0x0a)
                    {
                        findingStep = 0;
                        lastPacket = remove_appendant(makingPacket.ToArray());
                        try
                        {
                            rxPacket = new Pcr_Packet(lastPacket);
                            Console.WriteLine("rx= {0}, {1}", lastPacket.Length, BitConverter.ToString(lastPacket));
                            Console.WriteLine("PcrRxProcess success");
                            if (RevceivedPacket != null)
                            {
                                RevceivedPacket(this);
                            }
                        }
                        catch
                        {
                            fail = true;
                            Console.WriteLine("PcrRxProcess failed");
                        }
                    }
                    else
                    {
                        fail = true;
                    }
                }

                if (fail)
                {
                    lastData.AddRange(makingPacket);
                    makingPacket.Clear();
                    findingStep = 0;
                    fail = false;
                }
            }

            if (lastData.Count > 0)
            {
                output = lastData.ToArray();
                lastData.Clear();
            }

            if (output != null)
            {
                return output;
            }

            return null;
        }

        byte[] remove_appendant(byte[] input)
        {
            List<byte> array = new List<byte>(input);

            if (input.Length < 6)
            {
                Console.WriteLine("remove_appendant line size");
                //throw new ArgumentException();
                return null;
            }

            if (input[0] == 0x3a)
            {
                array.RemoveAt(0);
            }

            int idx = input.Length - 1;

            if (array.Last() == 0x0a)
            {
                array.RemoveAt(array.Count - 1);
            }

            if (array.Last() == 0x0d)
            {
                array.RemoveAt(array.Count - 1);
            }

            return array.ToArray();
        }

    }

    class Barcode_Packet
    {
        public int dataLen;
        public byte[] data;
        public uint data_val;
        public double data_float;

        public Optic_ItemCode Code;
        public Optic_SubItemCode SubCode;

        public Barcode_Packet()
        { }

        public Barcode_Packet(byte[] input)
        {
            bool rslt = parsingPacket(input);

            if (rslt == false)
            {
                throw new ArithmeticException("Pcr_Packet rx fail");
            }
        }

        public bool parsingPacket(byte[] input)
        {
            bool rslt = true;

            if ((input == null) || (input.Length != 7))
            {
                return false;
            }

            if (input[0] == (byte)Optic_ItemCode.FC_OPT_VAL)
            {
                Code = Optic_ItemCode.FC_OPT_VAL;
            }
            else if (input[0] == (byte)Optic_ItemCode.FC_OPT_BASE_VAL)
            {
                Code = Optic_ItemCode.FC_OPT_BASE_VAL;
            }
            else
            {
                rslt = false;
            }

            if (rslt)
            {
                if (Enum.IsDefined(typeof(Optic_SubItemCode), (int)input[1]))
                {
                    SubCode = (Optic_SubItemCode)input[1];
                }
                else
                {
                    rslt = false;
                }
            }

            if (rslt)
            {
                int len = input[2];

                if (len == 4)
                {
                    dataLen = 4;
                    data = new byte[dataLen];

                    for (int i = 0; i < dataLen; i++)
                    {
                        data[i] = Convert.ToByte(input[3 + i]);
                    }

                    if (BitConverter.IsLittleEndian)
                    {
                        Array.Reverse(data);
                    }

                    data_val = BitConverter.ToUInt32(data, 0);

                    if (Code == Optic_ItemCode.FC_OPT_VAL)
                    {
                        data_float = data_val * 0.000298026;
                    }
                    else if (Code == Optic_ItemCode.FC_OPT_BASE_VAL)
                    {
                        data_float = data_val * 0.000298026;
                    }

                }
                else
                {
                    rslt = false;
                }
            }

            if (rslt)
            {
                Debug.WriteLine(ToString());
            }

            return rslt;
        }

        public override string ToString()
        {
            return $"item code= {Code}, sub item code= {SubCode}, data= {data_val}, float={data_float}";
        }
    }

}
