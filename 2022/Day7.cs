using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2022
{
    public static class Day7
    {
        public static void FirstQuestion()
        {
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Input\\Day7.txt");
            string[] lines = File.ReadAllLines(path);

            MyDirectory root = new MyDirectory("/");

            ParseDirectory(root, lines, 1);
            SetDirectorySize(root);

            var directoriesLessThan100000 = new List<int>();
            CheckDirectoriesForSize(root, directoriesLessThan100000);
            // Keep the console window open in debug mode.
            Console.WriteLine(directoriesLessThan100000.Sum());
            System.Console.ReadKey();
        }
        public static void SecondQuestion()
        {
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Input\\Day7.txt");
            string[] lines = File.ReadAllLines(path);

            MyDirectory root = new MyDirectory("/");

            ParseDirectory(root, lines, 1);
            SetDirectorySize(root);

            var requiredSpace = 30000000 - (70000000 - root.TotalFileSize);
            var directoriesToDelete = new List<int>();
            CheckDirectoriesForSizeToDelete(root, directoriesToDelete, requiredSpace);
            // Keep the console window open in debug mode.
            Console.WriteLine(directoriesToDelete.OrderBy(x => x).FirstOrDefault());
            System.Console.ReadKey();
        }

        private static int ParseDirectory(MyDirectory root, string[] lines, int index)
        {
            for (; index < lines.Length; index++)
            {
                var splittedLine = lines[index].Split(' ');
                if (splittedLine[0] == "$")
                {
                    if (splittedLine[1] == "cd")
                    {
                        if (splittedLine[2] == "..")
                        {
                            break;
                        }
                        else
                        {
                            var newdirectory = new MyDirectory(splittedLine[2]);
                            index = ParseDirectory(newdirectory, lines, index + 1);
                            root.SubDirectories.Add(newdirectory);
                        }
                    }
                    else if (splittedLine[1] == "ls")
                    {
                        continue;
                    }
                }
                else
                {
                    int size;
                    bool isNumeric = int.TryParse(splittedLine[0], out size);
                    if (isNumeric)
                    {
                        root.FileSizes.Add(size);
                    }
                    else
                    {
                        continue;
                    }
                }
            }

            return index;
        }

        private static int SetDirectorySize(MyDirectory root)
        {
            int totalFileSize = root.FileSizes.Sum();

            foreach (var directory in root.SubDirectories)
            {
                totalFileSize += SetDirectorySize(directory);
            }

            root.TotalFileSize = totalFileSize;

            return totalFileSize;
        }
        private static void CheckDirectoriesForSize(MyDirectory root, List<int> validList)
        {
            if (root.TotalFileSize <= 100000)
            {
                validList.Add(root.TotalFileSize);
            }

            foreach (var directory in root.SubDirectories)
            {
                CheckDirectoriesForSize(directory, validList);
            }
        }
        private static void CheckDirectoriesForSizeToDelete(MyDirectory root, List<int> validList, int requiredSize)
        {
            if (root.TotalFileSize >= requiredSize)
            {
                validList.Add(root.TotalFileSize);
            }

            foreach (var directory in root.SubDirectories)
            {
                CheckDirectoriesForSizeToDelete(directory, validList, requiredSize);
            }
        }
    }

    internal class MyDirectory
    {
        public int TotalFileSize { get; set; }

        public string Name { get; set; }
        public List<int> FileSizes { get; set; }
        public List<MyDirectory> SubDirectories { get; set; }

        public MyDirectory(string name)
        {
            Name = name;
            FileSizes = new List<int>();
            SubDirectories = new List<MyDirectory>();
        }
    }

}
