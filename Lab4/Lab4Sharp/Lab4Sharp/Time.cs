using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Lab4Sharp
{
    public class Time
    {
        private int _hour;
        private int _minute;
        private int _second;

        public Time()
        {
            Hour = 0;
            Minute = 0;
            Second = 0;
        }

        public Time(int hour)
        {
            Hour = hour;
            Minute = 0;
            Second = 0;
        }

        public Time(int hour, int minute) : this(hour)
        {
            Minute = minute;
            Second = 0;
        }

        public Time(int hour, int minute, int second) : this(hour, minute)
        {
            Second = second;
        }
        

        public int Hour
        {
            get => _hour;
            private set
            {
                if (value >= 0) _hour = value % 24;
            }
        }

        public int Minute
        {
            get => _minute;
            private set
            {
                if (value >= 0)
                {
                    Hour += value / 60;
                    _minute = value % 60;
                }
                else
                {
                    Hour += value / 60 - 1;
                    _minute = 60 + value % 60;
                }
            }
        }

        public int Second
        {
            get => _second;
            private set
            {
                if (value >= 0)
                {
                    Minute += value / 60;
                    _second = value % 60;
                }
                else
                {
                    Minute += value / 60 - 1;
                    _second = 60 + value % 60;
                }
            }
        }


        public Time GetTimeToEndOfDay() => new Time(24 - _hour, 0 - _minute, 0 - _second);

        public void Print()
        {
            int[] properties = {_hour, _minute, _second};
            string[] printable =
                properties.Select(p => p.ToString().Length == 1 ? $"0{p}" : p.ToString()).ToArray();

            Console.WriteLine($"{printable[0]}:{printable[1]}:{printable[2]}");
        }

        public static Time? Parse(string str)
        {
            int[] nums = str.Split(new[] {' ', ',', '.', ':', ';', '/'}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            switch (nums.Length)
            {
                case 3:
                    return new Time(nums[0], nums[1], nums[2]);
                case 2:
                    return new Time(nums[0], nums[1]);
                case 1:
                    return new Time(nums[0]);
                default:
                    return null;
            }
        }

        public static Time operator +(Time time1, Time time2)
        {
            return new Time(time1.Hour + time2.Hour, time1.Minute + time2.Minute, time1.Second + time2.Second);
        }

        public static Time operator +(Time time, int minutes)
        {
            return new Time(time.Hour, time.Minute + minutes, time.Second);
        }

        public static Time operator -(Time time1, Time time2)
        {
            return new Time(time1.Hour - time2.Hour, time1.Minute - time2.Minute, time1.Second - time2.Second);
        }

        public static Time operator -(Time time, int minutes)
        {
            return new Time(time.Hour, time.Minute - minutes, time.Second);
        }
    }
}