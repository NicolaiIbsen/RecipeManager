using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecipeManager.Entities;
using System.Data;
using System.Data.SqlClient;

namespace RecipeManager.DBAccess
{
    public class DBHandler: DataRepository
    {
        public List<Ingredient> GetAllIngredients()
        {
            List<Ingredient> ingredients = new List<Ingredient>(0);
            string sql = $"SELECT * FROM Ingredients";
            DataSet set = Executor.Execute(sql);
            DataTable table = set.Tables[0];
            foreach( DataRow row in table.Rows )
            {
                int id = (int)row["IngredientId"];
                string name = (string)row["IngredientName"];
                decimal price = (decimal)row["Price"];
                IngredientType type = (IngredientType)Enum.Parse(typeof(IngredientType), (string)row["IngredientType"]);
                ingredients.Add(new Ingredient(id, name, price, type));
            }
            return ingredients;
        }
        public List<Recipe> GetAllRecipes()
        {
            List<Recipe> recipes = new List<Recipe>(0);
            string sql = $"SELECT * FROM Recipes";
            DataSet set = Executor.Execute(sql);
            DataTable table = set.Tables[0];
            foreach( DataRow row in table.Rows )
            {
                string name = (string)row["RecipeName"];
                recipes.Add(new Recipe(name));
            }

            return recipes;
        }
        public List<Ingredient> GetIngredientsByName(string recipe)
        {
            List<Ingredient> ingredients = new List<Ingredient>(0);
            string sql = $"SELECT RecipesIngredients.RecipeIngredientID, Recipes.RecipeID, Recipes.RecipeName, Ingredients.IngredientId, Ingredients.IngredientType, Ingredients.IngredientName, Ingredients.Price " +
                $"FROM RecipesIngredients " +
                $"JOIN Recipes ON Recipes.RecipeID = RecipesIngredients.RecipeID " +
                $"JOIN Ingredients ON Ingredients.IngredientID = RecipesIngredients.IngredientID";
            DataSet set = Executor.Execute(sql);
            DataTable table = set.Tables[0];
            foreach( DataRow row in table.Rows )
            {
                int id = (int)row["IngredientId"];
                string name = (string)row["IngredientName"];
                decimal price = (decimal)row["Price"];
                string type = (string)row["IngredientType"];
                if( recipe == (string)row["RecipeName"] )
                {
                    ingredients.Add(new Ingredient(id, name, price, (IngredientType)Enum.Parse(typeof(IngredientType), (string)row["IngredientType"])));
                }
            }
            return ingredients;
        }
        public Recipe GetRecipeByName(string recipe)
        {
            List<Ingredient> ingredients = new List<Ingredient>(0);
            List<decimal> costOfRecipe = new List<decimal>();
            string sql = $"SELECT RecipesIngredients.RecipeIngredientId, Recipes.RecipeId, Recipes.RecipeName, Ingredients.IngredientId, Ingredients.IngredientType, Ingredients.IngredientName, Ingredients.Price " +
                $"FROM RecipesIngredients " +
                $"JOIN Recipes ON Recipes.RecipeId = RecipesIngredients.RecipeId " +
                $"JOIN Ingredients ON Ingredients.IngredientId = RecipesIngredients.IngredientId";
            DataSet set = Executor.Execute(sql);
            DataTable table = set.Tables[0];
            foreach( DataRow row in table.Rows )
            {
                int id = (int)row["IngredientId"];
                string name = (string)row["IngredientName"];
                decimal price = (decimal)row["Price"];
                string type = (string)row["IngredientType"];
                if( recipe == (string)row["RecipeName"] )
                {
                    ingredients.Add(new Ingredient(id, name, price, (IngredientType)Enum.Parse(typeof(IngredientType), (string)row["IngredientType"])));
                }
            }
            return new Recipe(recipe, ingredients);
        }
        public void SaveIngredient(Ingredient ingredient)
        {
            string sql = "INSERT INTO Ingredients (IngredientName, Price, IngredientType)" +
                $"VALUES('{ingredient.Name}', {ingredient.Price}, '{ingredient.Type}')";
            Executor.Execute(sql);
        }
    }
}
