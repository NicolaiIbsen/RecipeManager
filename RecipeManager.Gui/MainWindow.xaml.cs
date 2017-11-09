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
using RecipeManager.Service;
using System.Data;
using System.Data.SqlClient;

namespace RecipeManager.Gui
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow: Window
    {
        List<Ingredient> newIngredientForRecipe = new List<Ingredient>();
        Ingredient ingredient = new Ingredient();
        DBHandler dbHandler = new DBHandler();
        ApiAccess apiAccess = new ApiAccess();
        public MainWindow()
        {
            InitializeComponent();
            /// Sees if there is any Exceptions in the beginning of the application
            try
            {
            listBoxRecipeList.ItemsSource = dbHandler.GetAllRecipes();
            listBoxRecipeList.SelectedIndex = 0;
            dataGridIngredientsInSelectedRecipe.ItemsSource = dbHandler.GetIngredientsByName(listBoxRecipeList.SelectedValue.ToString());
            dataGridIngredienser.ItemsSource = dbHandler.GetAllIngredients();
            dataGridAllIngredients.ItemsSource = dbHandler.GetAllIngredients();
            comboBoxTypes.ItemsSource = ingredient.GetListOfEnum();
            }
            catch( Exception e )
            {
                MessageBox.Show(e.Message);
            }
        }

        /// <summary>
        /// If the Selection changed in the listBoxRecipeList, it puts the ingredients for the selected item in the dataGridIngredientsInSelectedRecipe
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListBoxRecipeList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            dataGridIngredientsInSelectedRecipe.ItemsSource = dbHandler.GetIngredientsByName(listBoxRecipeList.SelectedValue.ToString());
            textBoxBoxPrice.Text = dbHandler.GetRecipeByName(listBoxRecipeList.SelectedValue.ToString()).GetPrice().ToString();
        }

        /// <summary>
        /// Adds a new ingredient to the DataBase
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonSubmitNewingrediense_Click(object sender, RoutedEventArgs e)
        {
            dbHandler.SaveIngredient(new Ingredient(textBoxName.Text, Convert.ToDecimal(textBoxPrice.Text), (IngredientType)Enum.Parse(typeof(IngredientType), comboBoxTypes.Text)));
            dataGridAllIngredients.ItemsSource = dbHandler.GetAllIngredients();
            dataGridIngredienser.ItemsSource = dbHandler.GetAllIngredients();
        }
        
        /// <summary>
        /// Takes information from Wikipedia and shows a summary of the selected "ingredient"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridAllIngredients_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                Ingredient h = dataGridAllIngredients.SelectedItem as Ingredient;
                MessageBox.Show(apiAccess.GetSummary(h.Name));
            }
            catch( Exception w )
            {

                MessageBox.Show(w.Message);
            }
        }

        /// <summary>
        /// Moves something from the dataGridAllIngredients to the dataGridItemsInNewRecipe
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonMoveItemRight_Click(object sender, RoutedEventArgs e)
        {
            newIngredientForRecipe.Add(dataGridAllIngredients.SelectedItem as Ingredient);
            dataGridItemsInNewRecipe.ItemsSource = null;
            dataGridItemsInNewRecipe.ItemsSource = newIngredientForRecipe;
        }
    }
}
