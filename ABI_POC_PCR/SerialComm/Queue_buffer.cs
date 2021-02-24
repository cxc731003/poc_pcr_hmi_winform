using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Concurrent;
using System.Diagnostics;

namespace ABI_POC_PCR.SerialComm
{
    public class Queue_buffer
    {
        private ConcurrentQueue<byte> buff = new ConcurrentQueue<byte>();

        public void qin(byte dt)
        {
            buff.Enqueue(dt);
        }

        public void qin(byte[] dt)
        {
            int i;

            for (i = 0; i < dt.Length; i++)
            {
                buff.Enqueue(dt[i]);
            }
        }

        public byte qout()
        {
            byte ch;

            if(!buff.TryDequeue(out ch))
            {
                throw new InvalidOperationException("Queue is emtpy!");
            }
            return ch;
        }

        public int qout(byte[] dt, int dt_start, int copy_len)
        {
            if (dt.Length < (copy_len+ dt_start))
            {
                //Debug.WriteLine("qout_all: out of range");
                Debug.Assert(false, "qout: out of range");
                throw new ArgumentOutOfRangeException();
            }

            int i;
            byte ch;

            for (i = 0; i < copy_len; i++)
            {
                if(buff.TryDequeue(out ch))
                {
                    dt[dt_start + i] = ch;
                }
                else
                {
                    break;
                }
            }

            return i;
        }

        /// <summary>
        /// 입력 버퍼 dt에 copy_len 만큼 queue에서 가져감
        /// </summary>
        /// <param name="dt">입력 버퍼</param>
        /// <param name="copy_len">가져갈 길이</param>
        /// <returns></returns>
        public int qout(byte[] dt, int copy_len)
        {
            int cnt = 0;

            if(dt.Length < copy_len)
            {
                //Debug.WriteLine("qout_all: out of range");
                Debug.Assert(false, "qout: out of range");
                throw new ArgumentOutOfRangeException();
            }
             
            for (int i = 0; i < copy_len; i++)
            {
                if(buff.TryDequeue(out dt[i]))
                {
                    cnt++;
                }
                else
                {
                    break;
                }
            }

            return cnt;
         }

        public int qsize()
        {
            return buff.Count;
        }

        public void qclear()
        {  
            while (buff.IsEmpty != true)
            {
                byte tmp;
                buff.TryDequeue(out tmp);
            }
        }

        public new string ToString()
        {
            byte[] bf = buff.ToArray(); // TODO: q에 데이터가 그대로 남음

            //return System.Text.Encoding.ASCII.GetString(bf);
            return System.Text.Encoding.UTF8.GetString(bf); // TODO: 예외 처리는?
        }


        public void Test()
        {
            Queue_buffer a = new Queue_buffer();
            a.qin(0x31);
            a.qin(0x32);
            a.qin(0x33);

            Console.WriteLine(a.ToString());
            Console.WriteLine(a.qsize());

            byte[] bf = new byte[a.qsize()];

            int len = a.qout(bf, a.qsize());
            string b = System.Text.Encoding.UTF8.GetString(bf, 0, len);

            Console.WriteLine(b);
            Console.WriteLine(a.qsize());
        }
    }

    public class Queue_buffer<T>
    {
        private ConcurrentQueue<T> buff = new ConcurrentQueue<T>();

        public void qin(T dt)
        {
            buff.Enqueue(dt);
        }

        public void qin(T[] dt)
        {
            int i;

            for (i = 0; i < dt.Length; i++)
            {
                buff.Enqueue(dt[i]);
            }
        }

        public T qout()
        {
            T ch;

            if (!buff.TryDequeue(out ch))
            {
                throw new InvalidOperationException("Queue is emtpy!");
            }

            return ch;
        }

        public bool qout(out T output)
        {
            return buff.TryDequeue(out output);
        }

        public int qout(T[] dt, int dt_start, int copy_len)
        {
            if (dt.Length < (copy_len + dt_start))
            {
                //Debug.WriteLine("qout_all: out of range");
                Debug.Assert(false, "qout: out of range");
                throw new ArgumentOutOfRangeException();
            }

            int i;
            T ch;

            for (i = 0; i < copy_len; i++)
            {
                if (buff.TryDequeue(out ch))
                {
                    dt[dt_start + i] = ch;
                }
                else
                {
                    break;
                }
            }

            return i;
        }

        /// <summary>
        /// 입력 버퍼 dt에 copy_len 만큼 queue에서 가져감
        /// </summary>
        /// <param name="dt">입력 버퍼</param>
        /// <param name="copy_len">가져갈 길이</param>
        /// <returns></returns>
        public int qout(T[] dt, int copy_len)
        {
            int cnt = 0;

            if (dt.Length < copy_len)
            {
                //Debug.WriteLine("qout_all: out of range");
                Debug.Assert(false, "qout: out of range");
                throw new ArgumentOutOfRangeException();
            }

            for (int i = 0; i < copy_len; i++)
            {
                if (buff.TryDequeue(out dt[i]))
                {
                    cnt++;
                }
                else
                {
                    break;
                }
            }

            return cnt;
        }


        public int qsize()
        {
            return buff.Count;
        }

        public void qclear()
        {
            while (buff.IsEmpty != true)
            {
                T tmp;
                buff.TryDequeue(out tmp);
            }
        }

    }
}
