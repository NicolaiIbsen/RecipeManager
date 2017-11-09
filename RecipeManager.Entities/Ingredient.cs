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
        public Ingredient(int ingredientId, string name, decimal price, IngredientType type)
        {
            IngredientId = ingredientId;
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
        public Ingredient()
        {

        }
        #endregion


        #region Properties
        public int IngredientId { get => ingredientId; set => ingredientId = value; }
        public string Name
        {
            get => name;
            set
            {
                (bool isValid, string error) = IsValidName(value);
                if( !isValid )
                    throw new ArgumentException(error, nameof(name));
                else
                {
                    name = value;
                }
            }
        }
        public decimal Price { get => price; set => price = value; }
        public IngredientType Type { get => type; set => type = value; }
        #endregion


        #region Methods
        public static (bool, string) IsValidName(string name)
        {
            if( String.IsNullOrWhiteSpace(name) )
            {
                return (false, "Blank eller tom");
            }
            else if( !name.All(c => Char.IsLetter(c)) )
            {
                return (false, "Kan ikke have tal i et navn");
            }
            return (true, String.Empty);
        }
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
