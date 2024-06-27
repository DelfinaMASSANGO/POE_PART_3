using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace RecipeApp
{
    public class Recipe
    {
        public string Name { get; set; }
        public List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
        public List<Step> Steps { get; set; } = new List<Step>();

        public class Ingredient
        {
            public string Name { get; set; }
            public double Quantity { get; set; }
            public string Unit { get; set; }
            public int Calories { get; set; }
            public string FoodGroup { get; set; }
            public double OriginalQuantity { get; set; }
        }

        public class Step : INotifyPropertyChanged
        {
            private bool isCompleted;

            public string Description { get; set; }

            public bool IsCompleted
            {
                get => isCompleted;
                set
                {
                    if (isCompleted != value)
                    {
                        isCompleted = value;
                        OnPropertyChanged(nameof(IsCompleted));
                    }
                }
            }

            public event PropertyChangedEventHandler PropertyChanged;

            protected virtual void OnPropertyChanged(string propertyName)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public void ResetQuantities()
        {
            foreach (var ingredient in Ingredients)
            {
                ingredient.Quantity = ingredient.OriginalQuantity;
            }
        }

        public void ScaleRecipe(double factor)
        {
            foreach (var ingredient in Ingredients)
            {
                ingredient.Quantity *= factor;
            }
        }

        public int TotalCalories => Ingredients.Sum(i => i.Calories);

        // Override ToString to display the recipe name in the ListBox
        public override string ToString()
        {
            return Name;
        }
    }
}
