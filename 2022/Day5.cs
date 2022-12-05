using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2022
{
    public static class Day5
    {
        public static void FirstQuestion()
        {
            var message = string.Empty;
            var stacks = PrepareStacks();

            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Input\\Day5.txt");
            string[] lines = File.ReadAllLines(path);

            foreach (var line in lines)
            {
                var splittedLine = line.Split(' ');
                var crateCount = Convert.ToInt32(splittedLine[1]);
                var stackFromIndex = Convert.ToInt32(splittedLine[3]) - 1;
                var stackToIndex = Convert.ToInt32(splittedLine[5]) - 1;

                for (int i = 0; i < crateCount; i++)
                {
                    var crate = stacks[stackFromIndex].Pop();
                    stacks[stackToIndex].Push(crate);
                }
            }

            foreach (var stack in stacks)
            {
                if (stack.Any())
                {
                    message += stack.Peek();
                }
            }

            Console.WriteLine(message);
            System.Console.ReadKey();
        }

        public static void SecondQuestion()
        {
            var message = string.Empty;
            var stacks = PrepareStacks();

            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Input\\Day5.txt");
            string[] lines = File.ReadAllLines(path);

            foreach (var line in lines)
            {
                var splittedLine = line.Split(' ');
                var crateCount = Convert.ToInt32(splittedLine[1]);
                var stackFromIndex = Convert.ToInt32(splittedLine[3]) - 1;
                var stackToIndex = Convert.ToInt32(splittedLine[5]) - 1;

                var crateBuffer = new List<string>();

                for (int i = 0; i < crateCount; i++)
                {
                    crateBuffer.Add(stacks[stackFromIndex].Pop());
                }

                for (int i = crateCount -1; i >= 0; i--)
                {
                    stacks[stackToIndex].Push(crateBuffer[i]);
                }

            }

            foreach (var stack in stacks)
            {
                if (stack.Any())
                {
                    message += stack.Peek();
                }
            }

            Console.WriteLine(message);
            System.Console.ReadKey();
        }

        private static List<Stack<string>> PrepareStacks()
        {
            List<Stack<string>> stacks = new List<Stack<string>>();
            stacks.Add(new Stack<string>(new List<string> { "D", "T", "W", "F", "J", "S", "H", "N" }));
            stacks.Add(new Stack<string>(new List<string> { "H", "R", "P", "Q", "T", "N", "B", "G" }));
            stacks.Add(new Stack<string>(new List<string> { "L", "Q", "V" }));
            stacks.Add(new Stack<string>(new List<string> { "N", "B", "S", "W", "R", "Q" }));
            stacks.Add(new Stack<string>(new List<string> { "N", "D", "F", "T", "V", "M", "B" }));
            stacks.Add(new Stack<string>(new List<string> { "M", "D", "B", "V", "H", "T", "R" }));
            stacks.Add(new Stack<string>(new List<string> { "D", "B", "Q", "J" }));
            stacks.Add(new Stack<string>(new List<string> { "D", "N", "J", "V", "R", "Z", "H", "Q" }));
            stacks.Add(new Stack<string>(new List<string> { "B", "N", "H", "M", "S" }));

            return stacks;
        }
    }
}
