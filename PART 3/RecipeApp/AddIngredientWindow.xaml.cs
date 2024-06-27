using System.Windows;
using System.Windows.Controls;

namespace RecipeApp
{
    public partial class AddIngredientWindow : Window
    {
        private Recipe Recipe { get; set; }

        public AddIngredientWindow(Recipe recipe)
        {
            InitializeComponent();
            Recipe = recipe;
        }

        private void AddIngredient_Click(object sender, RoutedEventArgs e)
        {
            var ingredient = new Recipe.Ingredient
            {
                Name = IngredientNameTextBox.Text,
                Quantity = double.Parse(QuantityTextBox.Text),
                Unit = UnitTextBox.Text,
                Calories = int.Parse(CaloriesTextBox.Text),
                FoodGroup = ((ComboBoxItem)FoodGroupComboBox.SelectedItem).Content.ToString(),
                OriginalQuantity = double.Parse(QuantityTextBox.Text)
            };

            Recipe.Ingredients.Add(ingredient);
            MessageBox.Show("Ingredient added successfully.");
            Close();
        }
    }
}
