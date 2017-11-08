using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.String;

namespace RecipeManager.Entities
{
    public class Recipe
    {
        #region MyRegion
        readonly int id;
        int persons;
        List<Ingredient> ingredients;
        string name;
        #endregion

        #region Constructors
        public Recipe(List<Ingredient> ingredients, string name, int persons)
        {
            Ingredients = ingredients;
            Name = name;
            Persons = persons;
        }

        public Recipe(int id, List<Ingredient> ingredients, string name, int persons)
            : this(ingredients, name, persons)
        {
            this.id = id;
        }
        #endregion

        #region Propeties
        public int Id => id;

        public List<Ingredient> Ingredients { get => ingredients; set => ingredients = value; }

        public string Name
        {
            get => name;
            set => name = value;
        }

        public int Persons { get => persons; set => persons = value; }
        #endregion

        #region Methods
        /// <summary>Validates a (possibly composite) name.</summary>
        /// <param name="name">The possibly composite name to validate.</param>
        /// <returns><see cref="bool"/> and <see cref="string"/></returns>
        public static (bool, string) IsNameValid(string name)
        {
            if(IsNullOrWhiteSpace(name))
                return (false, "Må ikke være blank");
            bool error;
            string errorMessage;
            string[] names = name.Split(new Char[] { ' ', '-' });
            if(!(name.Length > 0))
                return (false, "Må ikke være blank");
            else
            {
                foreach(string nameToValidate in names)
                {
                    (error, errorMessage) = Ingredient.IsNameValid(nameToValidate);
                    if(error)
                        return (false, errorMessage);
                }
                return (true, Empty);
            }
        }

        public virtual decimal GetPrice()
        {
            decimal total = default(decimal);
            if(ingredients.Count > 0)
                foreach(Ingredient ingredient in ingredients)
                    total += ingredient.Price;
            return total;
        }


        public override string ToString()
            => $"{name} har nok mad til {persons} personer og koster {GetPrice().ToString("C")} at lave";

        #endregion
    }
}
