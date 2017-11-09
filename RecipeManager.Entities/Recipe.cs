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
        private int amountOfPeople;
        private int recipeId;
        #endregion


        #region Constructor
        /// <summary>
        /// Creates a new object of the class(Recipe)
        /// </summary>
        /// <param name="ingredients"></param>
        /// <param name="name"></param>
        /// <param name="recipeId"></param>
        public Recipe(List<Ingredient> ingredients, string name, int recipeId)
        {
            Ingredients = ingredients;
            Name = name;
            RecipeId = recipeId;
        }
        /// <summary>
        /// Creates a new object of the class(Recipe)
        /// </summary>
        /// <param name="name"></param>
        /// <param name="ingredients"></param>
        public Recipe(string name, List<Ingredient> ingredients)
        {
            Name = name;
            Ingredients = ingredients;
        }
        /// <summary>
        /// Creates a new object of the class(Recipe)
        /// </summary>
        /// <param name="name"></param>
        public Recipe(string name)
        {
            Name = name;
        }
        #endregion


        #region Properties
        public List<Ingredient> Ingredients { get => ingredients; set => ingredients = value; }
        /// <summary>
        /// Sets the Name to name if there is no Exception, If there is it throws an exception
        /// </summary>
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
        /// <summary>
        /// Sets the AmountOfPeople to amountOfPeople if there is no Exception, If there is it throws an exception
        /// </summary>
        public int AmountOfPeople
        {
            get => amountOfPeople;
            set
            {
                (bool isValid, string error) = IsValidAmountOfPeople(value);
                if( !isValid )
                    throw new ArgumentException(error, nameof(amountOfPeople));
                else
                {
                    amountOfPeople = value;
                }
            }
        }
        public int RecipeId { get => recipeId; set => recipeId = value; }
        #endregion


        #region Methods
        /// <summary>
        /// Validates the name of the recipe
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Validate the amount of people the recipe is used for
        /// </summary>
        /// <param name="people"></param>
        /// <returns></returns>
        public static (bool, string) IsValidAmountOfPeople(int people)
        {
            if( people < 0 )
            {
                return (false, "Kan ikke være 0 eller mindre");
            }
            else if( !Convert.ToString(people).All(c => Char.IsDigit(c)) )
            {
                return (false, "Kan ikke bruge bogstaver");
            }
            return (true, String.Empty);
        }
        /// <summary>
        /// Gets the total price of the ingredients used in the recipe
        /// </summary>
        /// <returns></returns>
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
