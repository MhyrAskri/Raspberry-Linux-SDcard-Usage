using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace SystemUsage
{
    public class SdCard
    {
        public double Total;
        public double Used;
        public double Free;
    }
    class SdCardUsage
    {
        public SdCard GetSdCard()
        {
            var output = "";
            var info = new ProcessStartInfo("df -Bm");
            info.FileName = "/bin/bash";
            info.Arguments = "-c \"df -Bm\"";
            info.RedirectStandardOutput = true;

            using (var process = Process.Start(info))
            {
                output = process.StandardOutput.ReadToEnd();
                Console.WriteLine(output);
            }

            var lines = output.Split("\n").ToList();
            lines.RemoveAt(0);
            lines.RemoveAt(lines.Count - 1);

            var metrics = new SdCard();

            foreach (var item in lines)
            {
                metrics.Total += Convert.ToDouble(item.Split(" ", StringSplitOptions.RemoveEmptyEntries)[1].Replace("M", ""));
                metrics.Used += Convert.ToDouble(item.Split(" ", StringSplitOptions.RemoveEmptyEntries)[2].Replace("M", ""));
                metrics.Free += Convert.ToDouble(item.Split(" ", StringSplitOptions.RemoveEmptyEntries)[3].Replace("M", ""));
            }
            return metrics;
        }
    }
}
