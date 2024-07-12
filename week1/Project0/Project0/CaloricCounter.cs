using System;

namespace CaloricCounterApp
{
    // Encapsulation: Create a class to handle the daily calorie goal and meals
    public class CaloricCounter
    {
        private int goalCalories;
        public Meal Breakfast { get; set; }
        public Meal Lunch { get; set; }
        public Meal Dinner { get; set; }

        public int GoalCalories // Public property
        {
            get { return goalCalories; }
            private set { goalCalories = value; }
        }
        
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
