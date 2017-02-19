using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LargeSearchInfo.Core;
using System.IO;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace LargeSearchInfo
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch tere = new Stopwatch();
            tere.Start();
            Main parser = new Main();
            parser.StartParse();


            Console.WriteLine(new string('=', 79));
            tere.Stop();
            Console.WriteLine(tere.ElapsedMilliseconds);
            Console.WriteLine("Finish");

            Console.ReadKey();
        }

    }
}
