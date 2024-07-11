using System;

namespace CaloricCounterApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Text art at the beginning
            Console.WriteLine("********************************************");
            Console.WriteLine("*                                          *");
            Console.WriteLine("*        WELCOME TO CALORIC COUNTER        *");
            Console.WriteLine("*                                          *");
            Console.WriteLine("********************************************");

            // User Story 1: Ask the user for their goal calories
            Console.WriteLine("Enter your daily goal for calories:");
            int goalCalories;
            while (!int.TryParse(Console.ReadLine(), out goalCalories) || goalCalories < 0)
            {
                Console.WriteLine("Invalid input. Enter a valid positive number for goal calories:");
            }

            // User Story 2: Ask the user for breakfast item and calories
            Console.WriteLine("Enter breakfast item:");
            string breakfastName = Console.ReadLine();

            Console.WriteLine("Enter calories for breakfast:");
            int breakfastCalories;
            while (!int.TryParse(Console.ReadLine(), out breakfastCalories) || breakfastCalories < 0)
            {
                Console.WriteLine("Invalid input. Enter a valid positive number for calories:");
            }

            // User Story 3: Ask the user for lunch item and calories
            Console.WriteLine("Enter lunch item:");
            string lunchName = Console.ReadLine();

            Console.WriteLine("Enter calories for lunch:");
            int lunchCalories;
            while (!int.TryParse(Console.ReadLine(), out lunchCalories) || lunchCalories < 0)
            {
                Console.WriteLine("Invalid input. Enter a valid positive number for calories:");
            }

            // User Story 4: Ask the user for dinner item and calories
            Console.WriteLine("Enter dinner item:");
            string dinnerName = Console.ReadLine();

            Console.WriteLine("Enter calories for dinner:");
            int dinnerCalories;
            while (!int.TryParse(Console.ReadLine(), out dinnerCalories) || dinnerCalories < 0)
            {
                Console.WriteLine("Invalid input. Enter a valid positive number for calories:");
            }

            // Calculate total calories
            int totalCalories = breakfastCalories + lunchCalories + dinnerCalories;

            // Display meal details and total calories
            Console.WriteLine("\n********************************************");
            Console.WriteLine("*               MEAL DETAILS               *");
            Console.WriteLine("********************************************");
            Console.WriteLine($"Breakfast: {breakfastName} - {breakfastCalories} calories");
            Console.WriteLine($"Lunch: {lunchName} - {lunchCalories} calories");
            Console.WriteLine($"Dinner: {dinnerName} - {dinnerCalories} calories");
            Console.WriteLine($"Total Calories: {totalCalories}");

            // Compare to goal calories
            Console.WriteLine("\n********************************************");
            Console.WriteLine("*              GOAL COMPARISON             *");
            Console.WriteLine("********************************************");
            int difference = totalCalories - goalCalories;
            if (difference > 0)
            {
                Console.WriteLine($"You have exceeded your goal by {difference} calories.");
            }
            else if (difference < 0)
            {
                Console.WriteLine($"You are under your goal by {-difference} calories.");
            }
            else
            {
                Console.WriteLine("You have met your daily goal for calories.");
            }

            Console.ReadLine(); // Keep console open
        }
    }
}
