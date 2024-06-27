using System.Windows;

namespace RecipeApp
{
    public partial class ScaleRecipeWindow : Window
    {
        private Recipe Recipe { get; set; }

        public ScaleRecipeWindow(Recipe recipe)
        {
            InitializeComponent();
            Recipe = recipe;
        }

        private void ScaleRecipe_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(ScaleFactorTextBox.Text, out double scaleFactor))
            {
                Recipe.ScaleRecipe(scaleFactor);
                MessageBox.Show($"Recipe scaled by a factor of {scaleFactor}.");
                Close();
            }
            else
            {
                MessageBox.Show("Please enter a valid scale factor.");
            }
        }
    }
}
