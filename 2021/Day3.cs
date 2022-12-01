using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AdventOfCode
{
    public static class Day3
    {
        public static void FirstQuestion()
        {
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Input\\Day3.txt");
            string[] lines = File.ReadAllLines(path);

            var gamma = string.Empty;
            var epsilon = string.Empty;

            var lineLength = lines[0].Length;

            for (int i = 0; i < lineLength; i++)
            {
                var oneAmount = 0;
                var zeroAmount = 0;

                foreach (var line in lines)
                {
                    if (line[i] == '0')
                    {
                        zeroAmount++;
                    }
                    else
                    {
                        oneAmount++;
                    }
                }

                if (oneAmount > zeroAmount)
                {
                    gamma += '1';
                    epsilon += '0';
                }
                else
                {
                    gamma += '0';
                    epsilon += '1';
                }
            }

            var gammaNum = Convert.ToInt32(gamma, 2);
            var epsilonNum = Convert.ToInt32(epsilon, 2);

            var result = gammaNum * epsilonNum;

            Console.WriteLine(result);

            Console.ReadKey();
        }


        public static void SecondQuestion()
        {
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Input\\Day3.txt");
            string[] lines = File.ReadAllLines(path);
            var oxygenList = new List<string>(lines);
            var co2List = new List<string>(lines);

            var oxygen = string.Empty;
            var co2 = string.Empty;

            var lineLength = lines[0].Length;

            for (int i = 0; i < lineLength; i++)
            {
                oxygenList = RemoveNumber(oxygenList, i, true);
                co2List = RemoveNumber(co2List, i, false);
            }

            var oxygenNum = Convert.ToInt32(oxygenList[0], 2);
            var co2Num = Convert.ToInt32(co2List[0], 2);

            var result = oxygenNum * co2Num;

            Console.WriteLine(result);

            Console.ReadKey();
        }


        private static List<string> RemoveNumber(List<string> numbers, int index, bool common)
        {
            if (numbers.Count == 1)
            {
                return numbers;
            }

            var oneAmount = 0;
            var zeroAmount = 0;

            foreach (var number in numbers)
            {
                if (number[index] == '0')
                {
                    zeroAmount++;
                }
                else
                {
                    oneAmount++;
                }
            }

            var required = '0';
            if (oneAmount >= zeroAmount)
            {
                if (common)
                {
                    required = '1';
                }
            }
            else
            {
                if(!common)
                {
                    required = '1';
                }
            }

            var result = new List<string>();

            foreach (var number in numbers)
            {
                if (number[index] == required)
                {
                    result.Add(number);
                }
            }

            return result;
        }
    }
}
