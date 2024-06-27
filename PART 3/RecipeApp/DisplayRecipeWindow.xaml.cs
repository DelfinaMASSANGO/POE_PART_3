using System.Windows;

namespace RecipeApp
{
    public partial class DisplayRecipeWindow : Window
    {
        public DisplayRecipeWindow(Recipe recipe)
        {
            InitializeComponent();
            DataContext = recipe;
        }
    }
}
