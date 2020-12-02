﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace daytwo
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> inputPasswords = File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "input", "passwords.txt")).ToList();

            int totalCorrectPasswords = 0;
            int newTotalCorrectPasswords = 0;

            foreach (var input in inputPasswords)
            {
                string[] ruleToPassword = input.Split(": ");
                string[] rule = ruleToPassword[0].Split(" ");
                string[] minMax = rule[0].Split("-");

                string password = ruleToPassword[1];
                char letter = rule[1].ToCharArray()[0];

                int min = Int32.Parse(minMax[0]);
                int max = Int32.Parse(minMax[1]);

                int countRequired = Regex.Matches(password, rule[1]).Count;

                if (countRequired >= min && countRequired <= max)
                {
                    totalCorrectPasswords++;
                }

                char[] passwordAsCharArray = password.ToCharArray();
                if ((passwordAsCharArray[min-1] == letter && passwordAsCharArray[max-1] != letter) ||
                    (passwordAsCharArray[min-1] != letter && passwordAsCharArray[max-1] == letter))
                {
                    Console.WriteLine(input);
                    newTotalCorrectPasswords++;
                }
            }

            Console.WriteLine($"{totalCorrectPasswords}/{inputPasswords.Count}");
            Console.WriteLine($"{newTotalCorrectPasswords}/{inputPasswords.Count}");
        }

    }
}
