using System;
using ChallengeTracker.Services;

namespace ChallengeTracker
{
    /// <summary>
    /// User Stories:
    /// 1. As a user, I want to add a new entry for the 75 Hard Challenge so that I can track my daily progress.
    /// 2. As a user, I want to edit an existing entry so that I can update my progress if I made a mistake.
    /// 3. As a user, I want to see a monthly overview of my progress so that I can easily visualize my achievements and failures.
    /// 4. As a user, I want a simple and intuitive console menu so that I can navigate the application easily.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new instance of the Menu class
            Menu menu = new Menu();

            // Display the main menu to the user
            menu.DisplayMainMenu();
        }
    }
}