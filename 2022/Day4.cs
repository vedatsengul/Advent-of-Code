using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2022
{
    public static class Day4
    {
        public static void FirstQuestion()
        {
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Input\\Day4.txt");
            string[] lines = File.ReadAllLines(path);

            int overlappingPairs = 0;

            foreach (var line in lines)
            {
                var splittedLine = line.Split(',');

                var firstSplittedRange = splittedLine[0].Split('-');
                var secondSplittedRange = splittedLine[1].Split('-');

                var firstRangeStart = Convert.ToInt32(firstSplittedRange[0]);
                var firstRangeEnd = Convert.ToInt32(firstSplittedRange[1]);
                var secondRangeStart = Convert.ToInt32(secondSplittedRange[0]);
                var secondRangeEnd = Convert.ToInt32(secondSplittedRange[1]);

                if (firstRangeStart >= secondRangeStart && firstRangeEnd <= secondRangeEnd)
                {
                    overlappingPairs++;
                }
                else if (secondRangeStart >= firstRangeStart && secondRangeEnd <= firstRangeEnd)
                {
                    overlappingPairs++;
                }
            }
            // Keep the console window open in debug mode.
            Console.WriteLine(overlappingPairs);
            System.Console.ReadKey();
        }
        public static void SecondQuestion()
        {
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Input\\Day4.txt");
            string[] lines = File.ReadAllLines(path);

            int overlappingPairs = 0;

            foreach (var line in lines)
            {
                var splittedLine = line.Split(',');

                var firstSplittedRange = splittedLine[0].Split('-');
                var secondSplittedRange = splittedLine[1].Split('-');

                var firstRangeStart = Convert.ToInt32(firstSplittedRange[0]);
                var firstRangeEnd = Convert.ToInt32(firstSplittedRange[1]);
                var secondRangeStart = Convert.ToInt32(secondSplittedRange[0]);
                var secondRangeEnd = Convert.ToInt32(secondSplittedRange[1]);

                if (firstRangeStart >= secondRangeStart && firstRangeStart <= secondRangeEnd)
                {
                    overlappingPairs++;
                }
                else if (secondRangeStart >= firstRangeStart && secondRangeStart <= firstRangeEnd)
                {
                    overlappingPairs++;
                }
            }
            // Keep the console window open in debug mode.
            Console.WriteLine(overlappingPairs);
            System.Console.ReadKey();
        }
    }
}
