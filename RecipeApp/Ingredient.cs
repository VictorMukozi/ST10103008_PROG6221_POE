using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApp
{
   public class Ingredient
    {
        public string Name { get; private set; }
        public double Quantity { get; set; }
        public string Unit { get; private set; }
        public double Calories { get; private set; }
        public string FoodGroup { get; private set; }

        public Ingredient(string name, double quantity, string unit, double calories, string foodGroup)
        {
            Name = name;
            Quantity = quantity;
            Unit = unit;
            Calories = calories;
            FoodGroup = foodGroup;
        }

        public void ResetQuantity()
        {
            Quantity = 0;
        }
    }
}
