using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2022
{
    public static class Day9
    {
        public static void Solution()
        {
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Input\\Day9.txt");
            var commands = (File.ReadAllLines(path)).Select(c => new Command(c));
            const int knotCount = 10;
            var knots = new (int X, int Y)[knotCount];
            var visited = new HashSet<(int X, int Y)>();
            var visited10 = new HashSet<(int X, int Y)>();

            foreach (var command in commands)
            {
                for (var i = 0; i < command.Moves; i++)
                {
                    knots[0].X += command.Direction.X;
                    knots[0].Y += command.Direction.Y;

                    for (var k = 1; k < knotCount; k++)
                    {
                        var distanceX = knots[k - 1].X - knots[k].X;
                        var distanceY = knots[k - 1].Y - knots[k].Y;

                        if (Math.Abs(distanceX) > 1 || Math.Abs(distanceY) > 1)
                        {
                            knots[k].X += Math.Sign(distanceX);
                            knots[k].Y += Math.Sign(distanceY);
                        }
                    }
                    visited.Add(knots[1]);
                    visited10.Add(knots[knotCount - 1]);
                }
            }
            Console.WriteLine($"Part 1: {visited.Count}");
            Console.WriteLine($"Part 2: {visited10.Count}");
        }

        class Command
        {
            public Command(string line)
            {
                var cmd = line.Split(' ');
                Direction = cmd[0] switch
                {
                    "L" => (-1, 0),
                    "R" => (1, 0),
                    "D" => (0, -1),
                    "U" => (0, 1)
                };
                Moves = int.Parse(cmd[1]);
            }

            public (int X, int Y) Direction { get; set; }
            public int Moves { get; set; }
        }
    }
}