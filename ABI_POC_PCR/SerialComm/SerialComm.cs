using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Diagnostics;
using System.Windows.Forms;

namespace ABI_POC_PCR.SerialComm
{
    interface serialComm_interface
    {
        int send(string data);
        void send(byte[] data, int len);

        int rx_qcheck();
        void rx_qclear();

        byte[] Receive();
        string Receive_AsciiString();

        event Action<object> DelayedRxCallback;
    }

    public class SerialComm
    {
        object lock_threadCall = new object();

        SerialPort serial_port;
        Queue_buffer<byte[]> rxq;

        public event Action<object> DelayedRxCallback;

        private SerialComm()
        {
        }

        public SerialComm(SerialPort obj_serial) : this()
        {
            if (obj_serial == null)
            {
                Debug.WriteLine("시리얼 포트 초기화 오류");
                throw new ArgumentNullException("시리얼 포트 초기화 오류");
            }
            else
            {
                serial_port = obj_serial;
                rxq = new Queue_buffer<byte[]>();
                serial_port.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serial_DataReceived_callback);
            }
        }

        //---------------------------------------------------------------------------------
        // rx callback
        //---------------------------------------------------------------------------------

        private void serial_DataReceived_callback(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            Task.Factory.StartNew(() => serial_rx_CallBack());
        }

        private void serial_rx_CallBack()
        {
            int len;
            // 예외처리 필요함 

            try{
                lock (lock_threadCall)
                {
                    len = serial_port.BytesToRead;

                    if (len > 0)
                    {
                        byte[] rx_bf = new byte[len];

                        serial_port.Read(rx_bf, 0, len);
                        #region debug - display message
#if false
                    try
                    {
                        Debug.Write(Encoding.ASCII.GetString(rx_bf, 0, len));      // display 
                    }
                    catch
                    {
                        try
                        {
                            string str1 = BitConverter.ToString(rx_bf).Replace("-", " ");
                            Debug.WriteLine("\nprint BUFFER[{0}]: ", len + str1);
                        }
                        catch
                        {

                        }
                    }
#endif
                        #endregion
                        rxq.qin(rx_bf);
                    }

                    if (DelayedRxCallback != null)
                    {
                        DelayedRxCallback(this);
                    }
                }
            }
            catch(Exception e)
            {
                //MessageBox.Show("{0} Exception caught.", e.ToString());
            }


            

            //Debug.WriteLine("Comm: {0}", len);
        }

        //---------------------------------------------------------------------------------
        // interface
        //---------------------------------------------------------------------------------

        public int send(string data)
        {
            if (serial_port == null)
            {
                Debug.WriteLine("포트 없음");
                return -1;
            }
            if (!serial_port.IsOpen)
            {
                Debug.WriteLine("포트 에러");
                return -2;
            }

            serial_port.Write(data);

            return data.Length;
        }

        public void send(byte[] data, int len)
        {
            if (serial_port == null)
            {
                Debug.WriteLine("포트 없음");
                return;
            }
            if (!serial_port.IsOpen)
            {
                Debug.WriteLine("포트 에러");
                return;
            }

            serial_port.Write(data, 0, len);
        }

        /// <summary>
        /// serial data receive
        /// </summary>
        /// <returns>수신된 데이터</returns>
        public byte[] Receive()
        {
            List<byte> array = new List<byte>();
            byte[] read_bf;

            while (rxq.qout(out read_bf))
            {
                array.AddRange(read_bf);
            }

            return array.ToArray();
        }

        /// <summary>
        /// 문자열로 데이터를 받음
        /// </summary>
        /// <returns>문자열</returns>
        public string Receive_String()
        {
            byte[] bf = Receive();

            return System.Text.Encoding.ASCII.GetString(bf);
            //return System.Text.Encoding.UTF8.GetString(bf);
        }

        public int rx_qcheck()
        {
            return rxq.qsize();
        }

        public void rx_qclear()
        {
            rxq.qclear();
        }

    }
}
