using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AdventOfCode
{
    public static class Day4
    {
        public static void FirstQuestion()
        {
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Input\\Day4.txt");
            string[] lines = File.ReadAllLines(path);

            var draws = lines[0].Split(',');

            int boardCount = 1;
            List<BingoBoard> boards = new List<BingoBoard>();

            for (int i = 2; i < lines.Length; i++)
            {
                var newBoard = new BingoBoard(boardCount);

                for (int j = 0; j < 5; j++, i++)
                {
                    var boardLine = lines[i].Split(' ');

                    for (int k = 0, rowIndex = 0; k < boardLine.Length; k++)
                    {
                        if (string.IsNullOrEmpty(boardLine[k]))
                        {
                            continue;
                        }

                        newBoard.Numbers[j, rowIndex] = Convert.ToInt32(boardLine[k]);
                        rowIndex++;
                    }
                }

                boards.Add(newBoard);
                boardCount++;
            }

            var result = 0;
            foreach (var draw in draws)
            {
                var drawNumber = Convert.ToInt32(draw);
                int winnerSum = 0;

                foreach (var board in boards)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        for (int j = 0; j < 5; j++)
                        {
                            if (board.Numbers[i, j] == drawNumber)
                            {
                                board.Marks[i, j] = 1;

                                Console.WriteLine($"hit board {board.Key} with index {i}, {j} and draw number {drawNumber}");
                            }
                        }
                    }
                }

                foreach (var board in boards)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        if (winnerSum > 0)
                        {
                            break;
                        }

                        for (int j = 0; j < 5; j++)
                        {
                            if (board.Marks[i, j] == 0)
                            {
                                winnerSum = 0;
                                break;
                            }
                            winnerSum += board.Numbers[i, j];
                        }
                    }

                    if (winnerSum > 0)
                    {
                        Console.WriteLine($"draw number {drawNumber} and sum {winnerSum} on board {board.Key}");
                        result = drawNumber * winnerSum;
                        break;
                    }

                    for (int i = 0; i < 5; i++)
                    {
                        if (winnerSum > 0)
                        {
                            break;
                        }

                        for (int j = 0; j < 5; j++)
                        {
                            if (board.Marks[j, i] == 0)
                            {
                                winnerSum = 0;
                                break;
                            }
                            winnerSum += board.Numbers[j, i];
                        }
                    }

                    if (winnerSum > 0)
                    {
                        Console.WriteLine($"draw number {drawNumber} and sum {winnerSum} on board {board.Key}");
                        result = drawNumber * winnerSum;
                        break;
                    }
                }

                if (winnerSum > 0)
                {
                    break;
                }
            }

            Console.WriteLine(result);

            Console.ReadKey();
        }
    }

    public class BingoBoard
    {
        public int Key { get; set; }

        public int[,] Numbers { get; set; }
        public int[,] Marks { get; set; }

        public BingoBoard(int key)
        {
            Key = key;
            Numbers = new int[5, 5];
            Marks = new int[5, 5];
        }
    }
}
