using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace RecipeApp
{
    public partial class FilterRecipesWindow : Window
    {
        private List<Recipe> Recipes { get; set; }
        public List<Recipe> FilteredRecipes { get; set; }

        public FilterRecipesWindow(List<Recipe> recipes)
        {
            InitializeComponent();
            Recipes = recipes;
        }

        private void ApplyFilters_Click(object sender, RoutedEventArgs e)
        {
            string ingredient = IngredientTextBox.Text.ToLower();
            string foodGroup = ((ComboBoxItem)FoodGroupComboBox.SelectedItem)?.Content.ToString();
            int maxCalories = 0;
            int.TryParse(CaloriesTextBox.Text, out maxCalories);

            FilteredRecipes = Recipes.Where(r =>
                (string.IsNullOrEmpty(ingredient) || r.Ingredients.Any(i => i.Name.ToLower().Contains(ingredient))) &&
                (string.IsNullOrEmpty(foodGroup) || r.Ingredients.Any(i => i.FoodGroup == foodGroup)) &&
                (maxCalories == 0 || r.Ingredients.Sum(i => i.Calories) <= maxCalories)
            ).ToList();

            MessageBox.Show("Filters applied successfully.");
            Close();
        }
    }
}
