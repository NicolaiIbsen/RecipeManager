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
        private decimal price;
        private IngredientType type;
        #endregion


        #region Contructor
        public Ingredient(int id, string name, decimal price, IngredientType type)
        {
            ingredientId = id;
            Name = name;
            Price = price;
            Type = type;
        }
        public Ingredient(string name, decimal price, IngredientType type)
        {
            Name = name;
            Price = price;
            Type = type;
        }
        public Ingredient(string name)
        {
            Name = name;
        }
        #endregion


        #region Properties
        public int IngredientId { get => ingredientId; set => ingredientId = value; }
        public string Name { get => name; set => name = value; }
        public decimal Price { get => price; set => price = value; }
        public IngredientType Type { get => type; set => type = value; }
        #endregion


        #region Methods
        public List<string> GetListOfEnum()
        {
            return Enum.GetNames(typeof(IngredientType)).ToList();

        }
        public override string ToString()
        {
            return $"{ingredientId} {name} {price} {type}";
        }
        #endregion
    }
    
}
