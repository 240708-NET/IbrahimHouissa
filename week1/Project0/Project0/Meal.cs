using System;

namespace CaloricCounterApp
{
    // Encapsulation: Create a class to represent a Meal
    public class Meal
    {
        public string Name { get; set; }
        public int Calories { get; set; }

        public Meal(string name, int calories)
        {
            Name = name;
            Calories = calories;
        }

        public override string ToString()
        {
            return $"{Name} - {Calories} calories";
        }
    }
}
