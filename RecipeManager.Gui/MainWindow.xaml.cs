using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using RecipeManager.Entities;
using RecipeManager.DBAccess;

namespace RecipeManager.Gui
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow: Window
    {
        Ingredient ingredient = new Ingredient("");
        Recipe recipe = new Recipe();
        DBHandler dbHandler = new DBHandler();
        public MainWindow()
        {
            InitializeComponent();
            listBoxRecipeList.ItemsSource = dbHandler.GetAllRecipes();
            listBoxIngredienser.ItemsSource = dbHandler.GetAllIngredients();
            dataGridAllIngredients.ItemsSource = dbHandler.GetAllIngredients();
            comboBoxTypes.ItemsSource = ingredient.GetListOfEnum();
        }

        private void ListBoxRecipeList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            dataGridIngredientsInSelectedRecipe.ItemsSource = dbHandler.GetIngredientsByName(listBoxRecipeList.SelectedValue.ToString());
            textBoxBoxPrice.Text = dbHandler.GetRecipeByName(listBoxRecipeList.SelectedValue.ToString()).GetPrice().ToString();
        }

        private void ButtonSubmitNewingrediense_Click(object sender, RoutedEventArgs e)
        {
            Ingredient ingredient = new Ingredient(textBoxName.Text, Convert.ToDecimal(textBoxPrice.Text), (IngredientType)Enum.Parse(typeof(IngredientType), comboBoxTypes.Text));
            string sql = "INSERT INTO Ingredients (IngredientName, Price, IngredientType)" +
                $"VALUES('{ingredient.Name}', {ingredient.Price}, '{ingredient.Type}')";
            dbHandler.Executor.Execute(sql);
            listBoxIngredienser.ItemsSource = dbHandler.GetAllIngredients();
        }

        private void ButtonSearchForRecipe_Click(object sender, RoutedEventArgs e)
        {
            dataGridItemsInNewRecipe.ItemsSource = dbHandler.GetIngredientsByName(textBoxRecipeName.Text);
            labelTotalPrice.Content = recipe.GetPrice();
        }
    }
}
