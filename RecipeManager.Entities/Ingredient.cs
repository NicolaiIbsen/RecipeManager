using System;
using System.Linq;
using static System.String;

namespace RecipeManager.Entities
{
    /// <summary>Represents an ingredient.</summary>
    public class Ingredient
    {
        #region Fields
        /// <summary>The unique id for the row in the database, that represents this object.</summary>
        protected readonly int id;

        /// <summary>the name of the ingredient</summary>
        protected string name;

        /// <summary>The price of the ingredient.</summary>
        protected decimal price;

        /// <summary>The general type of ingredient for this ingredient.
        /// </summary>
        protected IngredientKind ingredientKind;
        #endregion


        #region Constructors
        public Ingredient(string name, decimal price, IngredientKind ingredientKind)
        {
            Name = name;
            Price = price;
            IngredientKind = ingredientKind;
        }

        public Ingredient(int id, string name, decimal price, IngredientKind ingredientKind)
            : this(name, price, ingredientKind)
        {
            this.id = id;
        }
        #endregion


        #region Properties
        /// <summary>gets the id of this object.</summary>
        public int Id => id;

        public virtual string Name
        {
            get => name;
            set
            {
                (bool isValid, string error) = IsNameValid(value);
                if(!isValid)
                    throw new ArgumentException(error, nameof(Name));
                else if(name != value)
                    name = value;
            }
        }

        public virtual IngredientKind IngredientKind
        {
            get => ingredientKind;
            set => ingredientKind = value;
        }

        public virtual decimal Price
        {
            get => price;
            set
            {
                (bool isValid, string error) = IsPriceValid(value);
                if(!isValid)
                    throw new ArgumentException(error, nameof(Price));
                else if(price != value)
                    price = value;
            }
        }
        #endregion


        #region Methods
        /// <summary>Validates that a name only consists of letters.</summary>
        /// <param name="name">The name to validate.</param>
        /// <returns>A <see cref="bool"/> indicating the validation result, and a <see cref="string"/> containg an error message.</returns>
        public static (bool, string) IsNameValid(string name)
            => name is null
            ? (false, "objektreferencen ikke indstillet til en forekomst")
            : !name.All(c => Char.IsLetter(c))
            ? (false, "Indeholder enten ingen, eller andre karakterer end, bogstaver")
            : (true, Empty);

        public static (bool, string) IsPriceValid(decimal price)
            => price > default(decimal) ? (true, Empty) : (false, "negativ værdi ikke tilladt");

        public override string ToString()
            => $"{name} er {ingredientKind} og koster {price.ToString("C")} pr. kg. at lave";
        #endregion
    }
}
