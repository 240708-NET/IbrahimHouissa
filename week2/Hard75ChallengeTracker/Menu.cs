using System;
using System.Linq;
using ChallengeTracker.Models;
using ChallengeTracker.Repositories;

namespace ChallengeTracker.Services
{
    public class Menu
    {
        // Repository to manage challenge entries
        private readonly IChallengeRepository _repository;

        // Constructor to initialize the repository
        public Menu()
        {
            _repository = new ChallengeRepository();
        }

        // Display the main menu to the user
        public void DisplayMainMenu()
        {
            while (true)
            {
                // Show menu options
                Console.WriteLine("75 Hard Challenge Tracker");
                Console.WriteLine("1. New Entry");
                Console.WriteLine("2. Edit Entry");
                Console.WriteLine("3. Monthly Overview");
                Console.WriteLine("4. Exit");
                Console.Write("Select an option: ");
                
                // Get user input
                var choice = Console.ReadLine();
                
                // Perform action based on user choice
                switch (choice)
                {
                    case "1":
                        AddNewEntry(); // Add a new entry
                        break;
                    case "2":
                        EditEntry(); // Edit an existing entry
                        break;
                    case "3":
                        ShowMonthlyOverview(); // Show the monthly overview
                        break;
                    case "4":
                        return; // Exit the application
                    default:
                        Console.WriteLine("Invalid choice, please try again."); // Handle invalid input
                        break;
                }
            }
        }

        // Method to add a new entry
        private void AddNewEntry()
        {
            // Get entry details from the user
            Console.Write("Enter the date (yyyy-mm-dd): ");
            DateTime date = DateTime.Parse(Console.ReadLine());

            Console.Write("Was the challenge completed (yes/no)? ");
            bool isCompleted = Console.ReadLine().ToLower() == "yes";

            Console.Write("Enter any notes: ");
            string notes = Console.ReadLine();

            // Add the entry to the repository
            _repository.AddEntry(new ChallengeEntry(date, isCompleted, notes));
        }

        // Method to edit an existing entry
        private void EditEntry()
        {
            // Get the date of the entry to edit
            Console.Write("Enter the date of the entry to edit (yyyy-mm-dd): ");
            DateTime date = DateTime.Parse(Console.ReadLine());

            // Find the entry in the repository
            var entry = _repository.GetEntryByDate(date);
            if (entry != null)
            {
                // Get updated details from the user
                Console.Write("Was the challenge completed (yes/no)? ");
                entry.IsCompleted = Console.ReadLine().ToLower() == "yes";

                Console.Write("Enter any notes: ");
                entry.Notes = Console.ReadLine();

                // Update the entry in the repository
                _repository.EditEntry(entry);
            }
            else
            {
                Console.WriteLine("Entry not found."); // Handle case where entry is not found
            }
        }

        // Method to show the monthly overview
        private void ShowMonthlyOverview()
        {
            // Get the year and month from the user
            Console.Write("Enter the year (yyyy): ");
            int year = int.Parse(Console.ReadLine());

            Console.Write("Enter the month (mm): ");
            int month = int.Parse(Console.ReadLine());

            // Get entries for the specified month
            var entries = _repository.GetEntriesForMonth(year, month);

            // Display the monthly overview
            Console.WriteLine("Monthly Overview:");
            for (int day = 1; day <= DateTime.DaysInMonth(year, month); day++)
            {
                var date = new DateTime(year, month, day);
                var entry = entries.FirstOrDefault(e => e.Date.Date == date.Date);

                // Display each day with its completion status
                if (entry != null)
                {
                    Console.Write(entry.IsCompleted ? $"({day}) " : $"[{day}] ");
                }
                else
                {
                    Console.Write($"{day} ");
                }
            }
            Console.WriteLine();
        }
    }
}
