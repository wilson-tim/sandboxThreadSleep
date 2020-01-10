using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class MainClass
    {
        public static void Main()
        {
            var data = tim();
        }
        public static async Task<string> tim()
        {
            DateTime endTime = DateTime.UtcNow.AddSeconds(10);
            int rowcount = 0;
            while (DateTime.UtcNow < endTime)
            {
                rowcount += 1;
                DateTime startTime = DateTime.UtcNow;
                Thread.Sleep(new Random().Next(10,500));
                int timeLeft = (int)(startTime.AddSeconds(1.0 / 10.0) - DateTime.UtcNow).TotalMilliseconds;   // 1 second divided by 10 (the maximum number of uploads per second)
                if (timeLeft > 0)
                {
                    Console.WriteLine(rowcount.ToString());
                    Console.WriteLine("Waiting " + timeLeft.ToString());
                    Console.WriteLine(DateTime.UtcNow.TimeOfDay.ToString());
                    Thread.Sleep(timeLeft);
                    //await Task.Delay(100);
                }
                else
                {
                    Console.WriteLine(rowcount.ToString());
                    Console.WriteLine("Continuing " + timeLeft.ToString());
//                    Console.WriteLine(DateTime.UtcNow.TimeOfDay.ToString());
                }
            }
            Thread.Sleep(1000);
            return "Done " + rowcount.ToString();
        }
    }
}
