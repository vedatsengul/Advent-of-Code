using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2022
{
    public static class Day3
    {
        public static void FirstQuestion()
        {
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Input\\Day3.txt");
            string[] lines = File.ReadAllLines(path);

            List<int> priorities = new List<int>();

            foreach (var line in lines)
            {
                HashSet<char> comparisionSet = new HashSet<char>();

                for (int i = 0; i < line.Length / 2; i++)
                {
                    comparisionSet.Add(line[i]);
                }

                char common = ' ';

                for (int i = line.Length / 2; i < line.Length; i++)
                {
                    if (comparisionSet.Contains(line[i]))
                    {
                        common = line[i];
                        break;
                    }
                }
                var priority = 0;
                var commonAscii = Encoding.ASCII.GetBytes(common.ToString());
                if (Char.IsLower(common))
                {
                    priority = commonAscii[0] - 96;
                }
                else
                {
                    priority = commonAscii[0] - 38;
                }
                priorities.Add(priority);
            }

            var total = priorities.Sum();

            Console.WriteLine(total);
            System.Console.ReadKey();
        }
        public static void SecondQuestion()
        {
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Input\\Day3.txt");
            string[] lines = File.ReadAllLines(path);

            List<int> priorities = new List<int>();

            for (int i = 0; i < lines.Length;)
            {
                var firstLine = lines[i];
                var secondLine = lines[i + 1];
                var thirdLine = lines[i + 2];

                Dictionary<char, int> comparisionSet = new Dictionary<char, int>();

                for (int j = 0; j < firstLine.Length; j++)
                {
                    if (!comparisionSet.ContainsKey(firstLine[j]))
                    {
                        comparisionSet.Add(firstLine[j], 1);
                    }
                }

                for (int j = 0; j < secondLine.Length; j++)
                {
                    if (comparisionSet.ContainsKey(secondLine[j]))
                    {
                        comparisionSet[secondLine[j]] = 2;
                    }
                }

                for (int j = 0; j < thirdLine.Length; j++)
                {
                    if (comparisionSet.ContainsKey(thirdLine[j]) && comparisionSet[thirdLine[j]] == 2)
                    {
                        comparisionSet[thirdLine[j]] = 3;
                    }
                }

                char common = ' ';

                foreach (var key in comparisionSet.Keys)
                {
                    if (comparisionSet[key] == 3)
                    {
                        common = key;
                        break;
                    }
                }

                var priority = 0;
                var commonAscii = Encoding.ASCII.GetBytes(common.ToString());
                if (Char.IsLower(common))
                {
                    priority = commonAscii[0] - 96;
                }
                else
                {
                    priority = commonAscii[0] - 38;
                }
                priorities.Add(priority);
                i += 3;
            }

            var total = priorities.Sum();

            Console.WriteLine(total);
            System.Console.ReadKey();
        }
    }
}
