using System;

namespace AdventOfCode
{
    class Program
    {
        static void Main(string[] args)
        {
            Day1_2();
        }

        private static void Day1()
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\temp\input.txt");

            var first = Convert.ToInt32(lines[0]);
            var count = 0;
            for (int i = 1; i < lines.Length; i++)
            {
                var next = Convert.ToInt32(lines[i]);
                if (first < next)
                {
                    count++;
                }

                first = next;
            }

            // Keep the console window open in debug mode.
            Console.WriteLine(count);
            System.Console.ReadKey();
        }

        private static void Day1_2()
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\temp\input.txt");

            var firstIndex = 0;
            var secondIndex = 1;
            var count = 0;

            while ((firstIndex + 2) < lines.Length && (secondIndex + 2 < lines.Length))
            {
                var first = Convert.ToInt32(lines[firstIndex]) + Convert.ToInt32(lines[firstIndex + 1]) + Convert.ToInt32(lines[firstIndex + 2]);
                var second = Convert.ToInt32(lines[secondIndex]) + Convert.ToInt32(lines[secondIndex + 1]) + Convert.ToInt32(lines[secondIndex + 2]);

                if (first < second)
                {
                    count++;
                }

                firstIndex++;
                secondIndex++;
            }

            // Keep the console window open in debug mode.
            Console.WriteLine(count);
            System.Console.ReadKey();
        }
    }

}
