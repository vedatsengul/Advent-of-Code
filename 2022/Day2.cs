using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2022
{
    public static class Day2
    {
        public static void FirstQuestion()
        {
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Input\\Day2.txt");
            string[] lines = File.ReadAllLines(path);

            int totalScore = 0;

            foreach (var line in lines)
            {
                var splittedLine = line.Split(' ');

                if (splittedLine[0] == "A")
                {
                    if (splittedLine[1] == "X")
                    {
                        totalScore += 4;
                    }
                    else if (splittedLine[1] == "Y")
                    {
                        totalScore += 8;
                    }
                    else if (splittedLine[1] == "Z")
                    {
                        totalScore += 3;
                    }
                }
                else if (splittedLine[0] == "B")
                {
                    if (splittedLine[1] == "X")
                    {
                        totalScore += 1;
                    }
                    else if (splittedLine[1] == "Y")
                    {
                        totalScore += 5;
                    }
                    else if (splittedLine[1] == "Z")
                    {
                        totalScore += 9;
                    }
                }
                else if (splittedLine[0] == "C")
                {
                    if (splittedLine[1] == "X")
                    {
                        totalScore += 7;
                    }
                    else if (splittedLine[1] == "Y")
                    {
                        totalScore += 2;
                    }
                    else if (splittedLine[1] == "Z")
                    {
                        totalScore += 6;
                    }
                }
            }
            // Keep the console window open in debug mode.
            Console.WriteLine(totalScore);
            System.Console.ReadKey();
        }
        public static void SecondQuestion()
        {
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Input\\Day2.txt");
            string[] lines = File.ReadAllLines(path);

            int totalScore = 0;

            foreach (var line in lines)
            {
                var splittedLine = line.Split(' ');

                if (splittedLine[0] == "A")
                {
                    if (splittedLine[1] == "X")
                    {
                        totalScore += 3;
                    }
                    else if (splittedLine[1] == "Y")
                    {
                        totalScore += 4;
                    }
                    else if (splittedLine[1] == "Z")
                    {
                        totalScore += 8;
                    }
                }
                else if (splittedLine[0] == "B")
                {
                    if (splittedLine[1] == "X")
                    {
                        totalScore += 1;
                    }
                    else if (splittedLine[1] == "Y")
                    {
                        totalScore += 5;
                    }
                    else if (splittedLine[1] == "Z")
                    {
                        totalScore += 9;
                    }
                }
                else if (splittedLine[0] == "C")
                {
                    if (splittedLine[1] == "X")
                    {
                        totalScore += 2;
                    }
                    else if (splittedLine[1] == "Y")
                    {
                        totalScore += 6;
                    }
                    else if (splittedLine[1] == "Z")
                    {
                        totalScore += 7;
                    }
                }
            }
            // Keep the console window open in debug mode.
            Console.WriteLine(totalScore);
            System.Console.ReadKey();
        }
    }
}
