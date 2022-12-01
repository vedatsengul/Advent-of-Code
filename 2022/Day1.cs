using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2022
{
    public static class Day1
    {
        public static void FirstQuestion()
        {
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Input\\Day1.txt");
            string[] lines = File.ReadAllLines(path);

            int maxCalories = 0;
            int currentElfCalories = 0;

            foreach (var line in lines)
            {
                if (string.IsNullOrEmpty(line))
                {
                    if (currentElfCalories > maxCalories)
                    {
                        maxCalories = currentElfCalories;
                    }
                    currentElfCalories = 0;
                }
                else
                {
                    int calories = Convert.ToInt32(line);
                    currentElfCalories += calories;
                }
            }
            if (currentElfCalories > maxCalories)
            {
                maxCalories = currentElfCalories;
            }
            // Keep the console window open in debug mode.
            Console.WriteLine(maxCalories);
            System.Console.ReadKey();
        }
        public static void SecondQuestion()
        {
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Input\\Day1.txt");
            string[] lines = File.ReadAllLines(path);

            int currentElfCalories = 0;

            List<int> caloriesList = new List<int>();

            foreach (var line in lines)
            {
                if (string.IsNullOrEmpty(line))
                {
                    caloriesList.Add(currentElfCalories);
                    currentElfCalories = 0;
                }
                else
                {
                    int calories = Convert.ToInt32(line);
                    currentElfCalories += calories;
                }
            }

            caloriesList.Add(currentElfCalories);

            caloriesList=caloriesList.OrderByDescending(x => x).ToList();

            var totalCalories = caloriesList[0] + caloriesList[1] + caloriesList[2];
            // Keep the console window open in debug mode.
            Console.WriteLine(totalCalories);
            System.Console.ReadKey();
        }
    }
}
