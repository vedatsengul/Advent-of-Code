using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AdventOfCode
{
    public static class Day2
    {
        public static void FirstQuestion()
        {
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Input\\Day2.txt");
            string[] lines = File.ReadAllLines(path);

            var horizontal = 0;
            var depth = 0;

            foreach (var line in lines)
            {
                var splittedLine = line.Split(' ');
                var command = splittedLine[0];
                var distance = Convert.ToInt32(splittedLine[1]);

                if (command == "forward")
                {
                    horizontal += distance;
                }
                else
                if (command == "up")
                {
                    depth -= distance;
                }
                else
                if (command == "down")
                {
                    depth += distance;
                }
            }

            // Keep the console window open in debug mode.
            Console.WriteLine(depth*horizontal);
            System.Console.ReadKey();
        }
        public static void SecondQuestion()
        {
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Input\\Day2.txt");
            string[] lines = File.ReadAllLines(path);

            var horizontal = 0;
            var depth = 0;
            var aim = 0;

            foreach (var line in lines)
            {
                var splittedLine = line.Split(' ');
                var command = splittedLine[0];
                var distance = Convert.ToInt32(splittedLine[1]);

                if (command == "forward")
                {
                    horizontal += distance;
                    depth = depth + (aim * distance);
                }
                else
                if (command == "up")
                {
                    aim -= distance;
                }
                else
                if (command == "down")
                {
                    aim += distance;
                }
            }

            // Keep the console window open in debug mode.
            Console.WriteLine(depth * horizontal);
            System.Console.ReadKey();
        }
    }
}
