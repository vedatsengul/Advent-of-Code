using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2022
{
    public static class Day6
    {
        public static void FirstQuestion()
        {

            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Input\\Day6.txt");
            string[] lines = File.ReadAllLines(path);
            string input = lines[0];

            int bufferIndex = 0;

            for (int i = 0; i < input.Length;)
            {
                Dictionary<char, int> buffer = new Dictionary<char, int>();
                int j = 0;
                for (; j < 4; j++)
                {
                    if (buffer.ContainsKey(input[i + j]))
                    {
                        i += buffer[input[i + j]] + 1;
                        break;
                    }
                    buffer.Add(input[i + j], j);
                }

                if (j == 4)
                {
                    bufferIndex = i + 4;
                    break;
                }
            }
            Console.WriteLine(bufferIndex);
            System.Console.ReadKey();
        }

        public static void SecondQuestion()
        {
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Input\\Day6.txt");
            string[] lines = File.ReadAllLines(path);
            string input = lines[0];

            int bufferIndex = 0;

            for (int i = 0; i < input.Length;)
            {
                Dictionary<char, int> buffer = new Dictionary<char, int>();
                int j = 0;
                for (; j < 14; j++)
                {
                    if (buffer.ContainsKey(input[i + j]))
                    {
                        i += buffer[input[i + j]] + 1;
                        break;
                    }
                    buffer.Add(input[i + j], j);
                }

                if (j == 14)
                {
                    bufferIndex = i + 14;
                    break;
                }
            }
            Console.WriteLine(bufferIndex);
            System.Console.ReadKey();
        }
    }
}
