using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RecipeManager.Service;
using RecipeManager.Entities;
using RecipeManager.DBAccess;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace RecipeManager.Tests
{
    [TestClass]
    public class ApiTests
    {
        [TestMethod]
        public void ApiPasses()
        {
            string page = "salt";
            string actual = (new ApiAccess().GetSummary(page));
            Assert.AreNotEqual(String.Empty, actual);
        }
    }
    [TestClass]
    public class RecipeTests
    {
        [TestMethod]
        public void GetPricePasses()
        {
            List<Ingredient> list = new List<Ingredient>();
            list.Add(new Ingredient("ds", 4, IngredientType.Meat));
            list.Add(new Ingredient("sd", 4, IngredientType.Meat));
            Recipe recipe = new Recipe("sd", list);
            decimal actual = 8;
            decimal expected = recipe.GetPrice();

            Assert.AreEqual(actual, expected);
        }
    }
    [TestClass]
    public class DataBaseTest
    {
        [TestMethod]
        public void DataExpectedAmountOfRows()
        {
            List<int> list = new List<int>();
            DBHandler dBHandler = new DBHandler();
            string sql = "SELECT * FROM RecipesIngredients WHERE IngredientId = 4";
            int expected = 2;
            int actual = 0;

            DataSet set = dBHandler.Executor.Execute(sql);
            DataTable table = set.Tables[0];
            foreach( DataRow row in table.Rows )
            {
                int id = (int)row["RecipeIngredientId"];
                list.Add(id);
            }
            actual = list.Count;

            Assert.AreEqual(expected, actual);
        }
    }
}
