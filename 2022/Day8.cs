using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2022
{
    public static class Day8
    {
        public static void FirstQuestion()
        {

            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Input\\Day8.txt");
            string[] lines = File.ReadAllLines(path);

            int visibleCount = 0;

            int[,] grid = new int[lines[0].Length, lines.Length];

            for (int i = 0; i < lines[0].Length; i++)
            {
                for (int j = 0; j < lines.Length; j++)
                {
                    grid[i, j] = Convert.ToInt32(lines[i][j].ToString());
                }
            }

            for (int i = 1; i < lines[0].Length - 1; i++)
            {
                for (int j = 1; j < lines.Length - 1; j++)
                {
                    if (IsVisible(i, j, grid))
                    {
                        visibleCount++;
                    }
                }
            }
            //add the edges right + left + top (-2 for the corners) + bottom (-2 for the corners)
            visibleCount += lines[0].Length + lines[0].Length + lines[0].Length - 2 + lines[0].Length - 2;
            Console.WriteLine(visibleCount);
            System.Console.ReadKey();
        }
        public static void SecondQuestion()
        {

            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Input\\Day8.txt");
            string[] lines = File.ReadAllLines(path);

            int maxScore = 0;

            int[,] grid = new int[lines[0].Length, lines.Length];

            for (int i = 0; i < lines[0].Length; i++)
            {
                for (int j = 0; j < lines.Length; j++)
                {
                    grid[i, j] = Convert.ToInt32(lines[i][j].ToString());
                }
            }

            for (int i = 1; i < lines[0].Length - 1; i++)
            {
                for (int j = 1; j < lines.Length - 1; j++)
                {
                    var score = CalculateSceneScore(i, j, grid);

                    if (score > maxScore)
                    {
                        maxScore = score;
                    }
                }
            }
            Console.WriteLine(maxScore);
            System.Console.ReadKey();
        }

        private static bool IsVisible(int i, int j, int[,] grid)
        {
            bool isHidden = false;
            //check left
            for (int k = 0; k < j; k++)
            {
                if (grid[i, j] <= grid[i, k])
                {
                    isHidden = true;
                    break;
                }
            }

            if (!isHidden)
            {
                return true;
            }

            isHidden = false;

            //check right
            for (int k = j + 1; k < grid.GetLength(0); k++)
            {
                if (grid[i, j] <= grid[i, k])
                {
                    isHidden = true;
                    break;
                }
            }

            if (!isHidden)
            {
                return true;
            }

            isHidden = false;

            //check top
            for (int k = 0; k < i; k++)
            {
                if (grid[i, j] <= grid[k, j])
                {
                    isHidden = true;
                    break;
                }
            }

            if (!isHidden)
            {
                return true;
            }

            isHidden = false;

            //check bottom
            for (int k = i + 1; k < grid.GetLength(1); k++)
            {
                if (grid[i, j] <= grid[k, j])
                {
                    isHidden = true;
                    break;
                }
            }

            if (!isHidden)
            {
                return true;
            }

            return false;
        }

        private static int CalculateSceneScore(int i, int j, int[,] grid)
        {
            int score = 1;
            //check left
            int count = 0;
            for (int k = j - 1; k >= 0; k--)
            {
                count++;
                if (grid[i, j] <= grid[i, k])
                {
                    break;
                }
            }
            score *= count;

            //check right
            count = 0;
            for (int k = j + 1; k < grid.GetLength(0); k++)
            {
                count++;
                if (grid[i, j] <= grid[i, k])
                {
                    break;
                }
            }
            score *= count;

            //check top
            count = 0;
            for (int k = i - 1; k >= 0; k--)
            {
                count++;
                if (grid[i, j] <= grid[k, j])
                {
                    break;
                }
            }
            score *= count;

            //check bottom
            count = 0;
            for (int k = i + 1; k < grid.GetLength(1); k++)
            {
                if (grid[i, j] <= grid[k, j])
                {
                    break;
                }
                count++;
            }
            score *= count;

            return score;
        }
    }
}
