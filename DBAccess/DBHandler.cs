using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecipeManager.Entities;

namespace RecipeManager.DBAccess
{
    class DBHandler : DataRepository
    {
        public List<Ingredient> GetAllIngredients()
        {
            return new List<Ingredient>(0);
        }
        public List<Recipe> GetAllRecipes()
        {
            return new List<Recipe>(0);
        }
        public Ingredient GetIngredientByName(string name)
        {
            return new Ingredient(0,"","",IngredientType.Dairy);
        }
        public Recipe GetRecipeByName(string name)
        {
            return new Recipe(new List<Ingredient>(0), "pogger", 3);
        }
    }
}
