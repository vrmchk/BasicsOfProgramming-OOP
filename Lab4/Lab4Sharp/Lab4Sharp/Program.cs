using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Lab4Sharp
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            Time[] timeArray =
            {
                new Time(18),
                new Time(14, 30, 40),
                new Time(3, 25)
            };
            
            TimeWorker.PrintTimeArray(timeArray, "Starting time");

            timeArray[0] += 17;
            timeArray[1] += 34;

            TimeWorker.PrintTimeArray(timeArray, "Changed time");

            Console.WriteLine("Difference between time 1 and 2");
            Time timeDifference = timeArray[0] - timeArray[1];
            timeDifference.Print();

            Console.WriteLine("\nTime from time 3 to the end of the day");
            timeArray[2].GetTimeToEndOfDay().Print();
            Console.ReadLine();

        }
    }
}