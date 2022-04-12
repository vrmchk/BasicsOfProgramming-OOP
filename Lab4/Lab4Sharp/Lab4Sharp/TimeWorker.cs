using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Lab4Sharp
{
    public class TimeWorker
    {
        public void Start() //запуск роботи з часом
        {
            Time[] timeArray =
            {
                new Time(18),
                new Time(14, 30, 40),
                new Time(3, 25)
            };
            
            PrintTimeArray(timeArray, "Starting time");

            timeArray[0] += 17;
            timeArray[1] += 34;

            PrintTimeArray(timeArray, "Changed time");

            Console.WriteLine("Difference between time 1 and 2");
            Time timeDifference = timeArray[0] - timeArray[1];
            timeDifference.Print();

            Console.WriteLine("\nTime from time 3 to the end of the day");
            timeArray[2].GetTimeToEndOfDay().Print();
            Console.ReadLine();
        }

        private void PrintTimeArray(Time[] timeArray, string prePrint = "") //вивести масив часу
        {
            Console.WriteLine(prePrint);
            Array.ForEach(timeArray, t => t.Print());
            Console.WriteLine();
        }

        private Time[] ConsoleArrayOfTimes(int size) //масив часу з даними з консолі
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