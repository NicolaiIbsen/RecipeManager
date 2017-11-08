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
        #endregion


        #region Properties
        public List<Ingredient> Ingredients { get => ingredients; set => ingredients = value; }
        public string Name { get => name; set => name = value; }
        public int RecipeId { get => recipeId; set => recipeId = value; }
        #endregion


        #region Methods
        public List<IngredientType> GetIngredientType()
        {
            return new List<IngredientType>();
        }
        public decimal GetPrice()
        {
            return 5;
        }
        public Recipe(string name, List<Ingredient> ingredients)
        {

        }
        public override string ToString()
        {
            return base.ToString();
        }
        #endregion
    }
}
