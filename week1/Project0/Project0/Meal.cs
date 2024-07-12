using System;

namespace CaloricCounterApp
{
    // Encapsulation: Create a class to represent a Meal
    public class Meal
    {
        private string name; // Private field
        private int calories; // Private field

        public string Name // Public getter and setter
        {
            get { return name; }
            private set { name = value; }
        }

        public int Calories // Public getter and setter
        {
            get { return calories; }
            private set { calories = value; }
        }

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
