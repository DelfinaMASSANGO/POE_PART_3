using System.Collections.Generic;
using System.Windows;

namespace RecipeApp
{
    public partial class CreateRecipeWindow : Window
    {
        public List<Recipe> Recipes { get; set; }
        private Recipe newRecipe;

        public CreateRecipeWindow(List<Recipe> recipes)
        {
            InitializeComponent();
            Recipes = recipes;
            newRecipe = new Recipe();
        }

        private void AddIngredients_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(NumIngredientsTextBox.Text, out int numIngredients))
            {
                for (int i = 0; i < numIngredients; i++)
                {
                    var addIngredientWindow = new AddIngredientWindow(newRecipe);
                    addIngredientWindow.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid number of ingredients.");
            }
        }

        private void AddSteps_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(NumIngredientsTextBox.Text, out int numSteps))
            {
                for (int i = 0; i < numSteps; i++)
                {
                    var addStepWindow = new AddStepWindow(newRecipe);
                    addStepWindow.ShowDialog();
                }
            }
        }

        private void CreateRecipe_Click(object sender, RoutedEventArgs e)
        {
            newRecipe.Name = RecipeNameTextBox.Text;
            Recipes.Add(newRecipe);
            MessageBox.Show("Recipe created successfully.");
            Close();
        }
    }
}
