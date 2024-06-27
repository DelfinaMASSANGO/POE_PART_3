using System.Windows;
using static RecipeApp.Recipe;

namespace RecipeApp
{
    public partial class AddStepWindow : Window
    {
        private Recipe Recipe { get; set; }

        public AddStepWindow(Recipe recipe)
        {
            InitializeComponent();
            Recipe = recipe;
        }

        private void AddStep_Click(object sender, RoutedEventArgs e)
        {
            var step = new Recipe.Step
            {
                Description = StepDescriptionTextBox.Text
            };

            Recipe.Steps.Add(step);
            MessageBox.Show("Step added successfully.");
            Close();
        }
    }
}
