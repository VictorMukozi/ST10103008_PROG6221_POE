using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RecipeApp
{
   public class Recipe
    {
        public string Name { get; set; }
        public List<Ingredient> Ingredients { get; private set; }
        public List<string> Steps { get; private set; }

        public Recipe()
        {
            Ingredients = new List<Ingredient>();
            Steps = new List<string>();
        }

        public void EnterDetails()
        {
            Name = PromptTextBox("Recipe Name:");

            int numIngredients;
            if (int.TryParse(PromptTextBox("Number of Ingredients:"), out numIngredients))
            {
                for (int i = 0; i < numIngredients; i++)
                {
                    string ingredientName = PromptTextBox($"Ingredient #{i + 1} Name:");
                    double quantity;
                    if (!double.TryParse(PromptTextBox($"Ingredient #{i + 1} Quantity:"), out quantity))
                    {
                        MessageBox.Show("Invalid quantity. Please try again.");
                        i--;
                        continue;
                    }
                    string unit = PromptTextBox($"Ingredient #{i + 1} Unit of Measurement:");
                    double calories;
                    if (!double.TryParse(PromptTextBox($"Ingredient #{i + 1} Calories:"), out calories))
                    {
                        MessageBox.Show("Invalid calories. Please try again.");
                        i--;
                        continue;
                    }
                    string foodGroup = PromptTextBox($"Ingredient #{i + 1} Food Group:");

                    Ingredient ingredient = new Ingredient(ingredientName, quantity, unit, calories, foodGroup);
                    Ingredients.Add(ingredient);
                }
            }

            int numSteps;
            if (int.TryParse(PromptTextBox("Number of Steps:"), out numSteps))
            {
                for (int i = 0; i < numSteps; i++)
                {
                    string description = PromptTextBox($"Step #{i + 1} Description:");
                    Steps.Add(description);
                }
            }

            MessageBox.Show("Recipe details entered successfully!");
        }

        public void DisplayRecipe()
        {
            string ingredientsText = string.Join("\n", Ingredients.Select(i => $"{i.Quantity} {i.Unit} {i.Name}"));
            string stepsText = string.Join("\n", Steps.Select((s, index) => $"{index + 1}. {s}"));
            double totalCalories = CalculateTotalCalories();

            string message = $"Recipe: {Name}\n\nIngredients:\n{ingredientsText}\n\nSteps:\n{stepsText}\n\nTotal Calories: {totalCalories}";

            MessageBox.Show(message);

            if (totalCalories > 300)
            {
                MessageBox.Show("Warning: Total calories exceed 300!");
            }
        }

        public void ScaleRecipe(double factor)
        {
            if (factor == 0.5 || factor == 2 || factor == 3)
            {
                foreach (Ingredient ingredient in Ingredients)
                {
                    ingredient.Quantity *= factor;
                }

                MessageBox.Show("Recipe scaled successfully!");
            }
            else
            {
                MessageBox.Show("Invalid scaling factor. Please enter 0.5, 2, or 3.");
            }
        }

        public void ResetQuantities()
        {
            foreach (Ingredient ingredient in Ingredients)
            {
                ingredient.ResetQuantity();
            }

            MessageBox.Show("Quantities reset to original values.");
        }

        public double CalculateTotalCalories()
        {
            return Ingredients.Sum(i => i.Calories);
        }

        private string PromptTextBox(string prompt)
        {
            return Microsoft.VisualBasic.Interaction.InputBox(prompt, "Enter Recipe Details");
        }
    }
}
