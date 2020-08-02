using System;
using SampleLibrary;

namespace ConsoleSample
{
    class Program
    {
        static void Main(string[] args)
        {
            var adder = new Adder();

            Console.WriteLine(adder.Add(2, 3));
        }
    }
}
