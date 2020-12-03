﻿using System;

namespace adventofcode
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 1)
            {
                Console.WriteLine("You must supply the number of the day to run.");
                return;
            }
            
            int day = Convert.ToInt32(args[0]);

            switch (day)
            {
                case 1:
                    Day01.Execute();
                    break;
                case 2:
                    Day02.Execute();
                    break;
                case 3:
                    Day03.Execute();
                    break;
                default:
                    Console.WriteLine($"Day {day} does not have a corresponding puzzle.");
                    break;
            }
        }
    }
}
