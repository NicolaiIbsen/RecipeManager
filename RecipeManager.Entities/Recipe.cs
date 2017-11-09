using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeManager.Entities
{
    public class Recipe
    {
        #region Fields
        private List<Ingredient> ingredients;
        private string name;
        private int recipeId;
        #endregion


        #region Constructor
        public Recipe(List<Ingredient> ingredients, string name, int recipeId)
        {
            Ingredients = ingredients;
            Name = name;
            RecipeId = recipeId;
        }
        public Recipe(string name, List<Ingredient> ingredients)
        {
            Name = name;
            Ingredients = ingredients;
        }
        public Recipe(string name)
        {
            Name = name;
        }
        public Recipe()
        {

        }
        #endregion


        #region Properties
        public List<Ingredient> Ingredients { get => ingredients; set => ingredients = value; }
        public string Name { get => name; set => name = value; }
        public int RecipeId { get => recipeId; set => recipeId = value; }
        #endregion


        #region Methods
        public decimal GetPrice()
        {
            decimal price = 0;
            for( int i = 0; i < ingredients.Count; i++ )
            {
                price += ingredients[i].Price;
            }
            return price;
        }
        public override string ToString()
        {
            return $"{name}";
        }
        #endregion
    }
}
