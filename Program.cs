using System;
using System.Diagnostics;
using System.Threading;

namespace SystemUsage
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new SdCardUsage();
            while (true)
            {
                var metrics = client.GetSdCard();

                Console.WriteLine("Total: " + metrics.Total);
                Console.WriteLine("Used : " + metrics.Used);
                Console.WriteLine("Free : " + metrics.Free);
                Thread.Sleep(1000);
            }
        }
    }
}
