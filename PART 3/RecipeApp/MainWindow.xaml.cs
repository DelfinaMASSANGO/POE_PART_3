using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace RecipeApp
{
    public partial class MainWindow : Window
    {
        public List<Recipe> Recipes { get; set; } = new List<Recipe>();

        public MainWindow()
        {
            InitializeComponent();
            RecipeListBox.ItemsSource = Recipes.OrderBy(r => r.Name).ToList();
        }

        private void CreateRecipe_Click(object sender, RoutedEventArgs e)
        {
            var createRecipeWindow = new CreateRecipeWindow(Recipes);
            createRecipeWindow.ShowDialog();
            RecipeListBox.ItemsSource = Recipes.OrderBy(r => r.Name).ToList();
        }

        private void ScaleRecipe_Click(object sender, RoutedEventArgs e)
        {
            if (RecipeListBox.SelectedItem is Recipe selectedRecipe)
            {
                var scaleRecipeWindow = new ScaleRecipeWindow(selectedRecipe);
                scaleRecipeWindow.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select a recipe to scale.");
            }
        }

        private void ResetQuantities_Click(object sender, RoutedEventArgs e)
        {
            if (RecipeListBox.SelectedItem is Recipe selectedRecipe)
            {
                selectedRecipe.ResetQuantities();
                MessageBox.Show("Quantities have been reset.");
            }
            else
            {
                MessageBox.Show("Please select a recipe to reset.");
            }
        }

        private void DeleteRecipe_Click(object sender, RoutedEventArgs e)
        {
            if (RecipeListBox.SelectedItem is Recipe selectedRecipe)
            {
                Recipes.Remove(selectedRecipe);
                RecipeListBox.ItemsSource = Recipes.OrderBy(r => r.Name).ToList();
                MessageBox.Show("Recipe deleted.");
            }
            else
            {
                MessageBox.Show("Please select a recipe to delete.");
            }
        }

        private void FilterRecipes_Click(object sender, RoutedEventArgs e)
        {
            var filterRecipesWindow = new FilterRecipesWindow(Recipes);
            filterRecipesWindow.ShowDialog();
            RecipeListBox.ItemsSource = filterRecipesWindow.FilteredRecipes;
        }

        private void DisplayRecipe_Click(object sender, RoutedEventArgs e)
        {
            if (RecipeListBox.SelectedItem is Recipe selectedRecipe)
            {
                var displayRecipeWindow = new DisplayRecipeWindow(selectedRecipe);
                if (selectedRecipe.TotalCalories > 300)
                {
                    NotifyUser("WARNING!! WARNING!!: This recipe exceeds 300 calories!");
                }
                displayRecipeWindow.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select a recipe to display.");
            }
        }

        private void RecipeListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Optional: Handle selection change if needed
        }

        private void NotifyUser(string message)
        {
            MessageBox.Show(message, "Notification", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
    }
}
