using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeManager.Entities
{
    public class Ingredient
    {
        #region Fields
        private int ingredientId;
        private string name;
        private string price;
        private IngredientType type;
        #endregion


        #region Contructor
        public Ingredient(int ingredientId, string name, string price, IngredientType type)
        {
            IngredientId = ingredientId;
            Name = name;
            Price = price;
            Type = type;
        }
        #endregion


        #region Properties
        public int IngredientId { get => ingredientId; set => ingredientId = value; }
        public string Name { get => name; set => name = value; }
        public string Price { get => price; set => price = value; }
        public IngredientType Type { get => type; set => type = value; }
        #endregion


        #region Methods
        public Ingredient(decimal price, string name, IngredientType type)
        {

        }
        public override string ToString()
        {
            return base.ToString();
        }
        #endregion
    }
    
}
