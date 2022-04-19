using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Lab4Sharp
{
    public static class TimeWorker
    {
        public static void PrintTimeArray(Time[] timeArray, string prePrint = "") //вивести масив часу
        {
            Console.WriteLine(prePrint);
            Array.ForEach(timeArray, Console.WriteLine);
            Console.WriteLine();
        }

        public static Time[] ConsoleArrayOfTimes(int size) //масив часу з даними з консолі
        {
            var timeArray = new Time[size];
            for (int i = 0; i < size; i++)
            {
                Console.Write("Enter time(hh:mm:ss): ");
                timeArray[i] = Time.Parse(Console.ReadLine()!)!;
            }

            return timeArray;
        }
    }
}