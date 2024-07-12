using System;

namespace CaloricCounterApp
{
    // Encapsulation: Create a class to handle the daily calorie goal and meals
    public class CaloricCounter
    {
        public int GoalCalories { get; set; }
        public Meal Breakfast { get; set; }
        public Meal Lunch { get; set; }
        public Meal Dinner { get; set; }

        public CaloricCounter(int goalCalories)
        {
            GoalCalories = goalCalories;
        }

        public int TotalCalories()
        {
            return (Breakfast?.Calories ?? 0) + (Lunch?.Calories ?? 0) + (Dinner?.Calories ?? 0);
        }

        public int CompareToGoal()
        {
            return TotalCalories() - GoalCalories;
        }
    }
}
