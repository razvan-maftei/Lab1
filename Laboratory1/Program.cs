using System;
using System.Collections.Generic;
using System.Threading;

namespace Laboratory1
{
    internal class Program
    {
        
        public static String GetTimestamp(DateTime value)
        {
            return value.ToString("HH::mms::s::ffff");
        }
        
        public static void Main(string[] args)
        {
            var num = Convert.ToInt32(Console.ReadLine());

            var list = new List<string>();

            var threadOne = new Thread(async delegate () {
                list.Add($"Start Fir: FirstMethod {GetTimestamp(DateTime.Now)} Numar natural dat: {num}");
                var result = await Prime.MethodOne(num);
                list.Add($"End Fir: FirstMethod {GetTimestamp(DateTime.Now)} Numar prim dat: {result}");
            });
            var threadTwo = new Thread(async delegate () {
                list.Add($"Start Fir: SecondMethod {GetTimestamp(DateTime.Now)} Numar natural dat: {num}");
                var result = await Prime.MethodTwo(num);
                list.Add($"End Fir: SecondMethod {GetTimestamp(DateTime.Now)} Numar prim dat: {result}");
            });
            threadOne.Name = "FirstMethod";
            threadTwo.Name = "SecondMethod";
            String timeStamp = GetTimestamp(DateTime.Now);
            threadOne.Start();
            threadTwo.Start();
            // System.Threading.Thread.Sleep(500);
            threadOne.Join();
            threadTwo.Join();
            foreach (var entry in list)
            {
                Console.WriteLine(entry);
            }
        }
    }
}