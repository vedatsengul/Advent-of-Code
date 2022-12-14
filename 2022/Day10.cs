using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2022
{
    public static class Day10
    {
        public static void FirstQuestion()
        {

            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Input\\Day10.txt");
            string[] lines = File.ReadAllLines(path);

            int signalSum = 0;
            int registerIndex = 1;
            int cycleCounter = 1;

            foreach (string line in lines)
            {
                if (cycleCounter % 40 == 20)
                {
                    signalSum += (cycleCounter * registerIndex);
                }

                var splittedLine = line.Split(' ');

                if (splittedLine.Length == 1)
                {
                    cycleCounter++;
                }
                else
                {
                    cycleCounter++;

                    if (cycleCounter % 40 == 20)
                    {
                        signalSum += (cycleCounter * registerIndex);
                    }

                    registerIndex += Convert.ToInt32(splittedLine[1]);
                    cycleCounter++;
                }
            }

            Console.WriteLine(signalSum);
            System.Console.ReadKey();
        }
        public static void SecondQuestion()
        {

            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Input\\Day10.txt");
            string[] lines = File.ReadAllLines(path);

            int registerIndex = 1;
            int cursor = 1;

            foreach (string line in lines)
            {
                var splittedLine = line.Split(' ');

                if (splittedLine.Length == 1)
                {
                    Print(registerIndex, cursor);
                    cursor++;
                }
                else
                {
                    Print(registerIndex, cursor);
                    cursor++;

                    if (cursor == 41)
                    {
                        Console.WriteLine();
                        cursor = 1;
                    }

                    Print(registerIndex, cursor);
                    cursor++;

                    registerIndex += Convert.ToInt32(splittedLine[1]);
                }

                if (cursor == 41)
                {
                    Console.WriteLine();
                    cursor = 1;
                }
            }

            System.Console.ReadKey();
        }

        private static void Print(int registerIndex, int cursor)
        {
            if (cursor >= registerIndex && cursor <= (registerIndex + 2))
            {
                Console.Write('#');
            }
            else
            {
                Console.Write('.');
            }
        }
    }
}
