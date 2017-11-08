using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecipeManager.Entities;
using static System.String;
using System.Data;

namespace RecipeManager.DataAccess
{
    public class RecipeRepository: RepositoryBase
    {
        public RecipeRepository()
        {
        }

        public virtual List<Recipe> GetAllRecipes()
        {
            List<Recipe> recipes = new List<Recipe>(0);

            return recipes;
        }

        public virtual List<Ingredient> GetAllIngredients()
        {
            List<Ingredient> ingredients = new List<Ingredient>(0);
            try
            {
                string sql = "SELECT * FROM Ingredients";
                DataSet set = executor.Execute(sql);
                foreach(DataRow row in set.Tables[0].Rows)
                {
                    ingredients.Add(ExtractIngredientFrom(row));
                }
                return ingredients;
            }
            catch(Exception)
            {
                throw;
            }
        }

        public virtual Ingredient GetIngredientBy(string name)
        {
            if(IsNullOrWhiteSpace(name))
                throw new ArgumentException(nameof(name));
        }

        public virtual Recipe GetRecipeBy(string name)
        {
            if(IsNullOrWhiteSpace(name))
                throw new ArgumentException(nameof(name));
            string sql = $"SELECT * FROM Recipes WHERE Name='{name}'";
            try
            {
                DataSet result = executor.Execute(sql);
                foreach(DataRow row in result.Tables[0].Rows)
                {
                    
                }
            }
            catch(Exception)
            {

                throw;
            }
        }

        protected virtual Recipe ExtractRecipeFrom(DataTable joinTable)
        {
            try
            {
                DataTable recipeTable = new DataTable();
                DataTable ingredientTable = new DataTable();
                int currentRecipeId = 0;
                recipeTable.Columns[]
                foreach(DataRow joinRow in joinTable.Rows)
                {
                    int recipeId = (int)joinRow["RecipeId"];
                    string recipeName = (string)joinRow["RecipeName"];
                    if(currentRecipeId <= recipeId)
                    {
                        currentRecipeId = recipeId;
                        
                        ingredientTable.Rows.Add(joinRow["IngredientId"], joinRow["IngredientName"], joinRow["Price"], joinRow["IngredientType"]);
                    }
                }
            }
            catch(Exception)
            {

                throw;
            }
        }

        protected virtual 

        protected virtual Ingredient ExtractIngredientFrom(DataRow row)
        {
            try
            {
                int id = (int)row["IngredientId"];
                string name = (string)row["Ingredientname"];
                decimal price = (decimal)row["Price"];
                IngredientKind kind = (IngredientKind)row["IngredientType"];
                Ingredient i = new Ingredient(id, name, price, kind);
                return i;
            }
            catch(Exception)
            {
                throw;
            }
        }
    }
}
