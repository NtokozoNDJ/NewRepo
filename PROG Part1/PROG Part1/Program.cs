using System;
using System.Collections.Generic;

namespace RecipeApp
{
    // Represents an ingredient in a recipe
    class Ingredient
    {
        public string Name { get; set; } // Name of the ingredient
        public double Quantity { get; set; } // Quantity of the ingredient
        public string Unit { get; set; } // Unit of measurement for the quantity
        public double DefaultQuantity { get; set; } // Store default quantity for scaling
    }

    // Represents a step in a recipe
    class Step
    {
        public string Description { get; set; } // Description of the step
    }

    // Represents a recipe consisting of ingredients and steps
    class Recipe
    {
        public List<Ingredient> Ingredients { get; set; } // List of ingredients in the recipe
        public List<Step> Steps { get; set; } // List of steps in the recipe

        // Constructor to initialize lists
        public Recipe()
        {
            Ingredients = new List<Ingredient>();
            Steps = new List<Step>();
        }

        // Display the recipe including ingredients and steps
        public void DisplayRecipe()
        {
            Console.WriteLine("\nRecipe:");
            Console.WriteLine("Ingredients:");
            foreach (Ingredient ingredient in Ingredients)
            {
                Console.WriteLine($"- {ingredient.Quantity} {ingredient.Unit} of {ingredient.Name}");
            }
            Console.WriteLine("\nSteps:");
            foreach (Step step in Steps)
            {
                Console.WriteLine($"- {step.Description}");
            }
        }

        // Scale the quantities of ingredients by a given factor
        public void ScaleRecipe(double scaleFactor)
        {
            foreach (Ingredient ingredient in Ingredients)
            {
                ingredient.Quantity *= scaleFactor;
            }
        }

        // Store default quantities of ingredients for scaling
        public void StoreDefaultQuantities()
        {
            foreach (Ingredient ingredient in Ingredients)
            {
                ingredient.DefaultQuantity = ingredient.Quantity; // Store default quantity
            }
        }

        // Reset ingredient quantities to their default values
        public void ResetQuantities()
        {
            foreach (Ingredient ingredient in Ingredients)
            {
                ingredient.Quantity = ingredient.DefaultQuantity; // Reset to default quantity
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Recipe recipe = new Recipe(); // Create a new recipe instance
            bool running = true; // Flag to control program execution

            while (running)
            {
                // Display menu options for user
                Console.WriteLine("1. Enter recipe details");
                Console.WriteLine("2. Display recipe");
                Console.WriteLine("3. Scale recipe");
                Console.WriteLine("4. Reset quantities");
                Console.WriteLine("5. Clear all data");
                Console.WriteLine("6. Exit");

                int choice = int.Parse(Console.ReadLine()); // Get user choice

                switch (choice)
                {
                    case 1:
                        EnterRecipeDetails(recipe); // Call function to enter recipe details
                        break;
                    case 2:
                        recipe.DisplayRecipe(); // Call method to display recipe
                        break;
                    case 3:
                        Console.WriteLine("Enter scaling factor (0.5 for half, 2 for double, 3 for triple):");
                        double scaleFactor = double.Parse(Console.ReadLine());
                        recipe.ScaleRecipe(scaleFactor); // Call method to scale recipe
                        break;
                    case 4:
                        recipe.ResetQuantities(); // Call method to reset quantities
                        break;
                    case 5:
                        recipe = new Recipe(); // Clear all recipe data
                        Console.WriteLine("All data cleared.");
                        break;
                    case 6:
                        running = false; // Exit the program
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a number between 1 and 6.");
                        break;
                }
            }
        }

        // Function to enter recipe details
        static void EnterRecipeDetails(Recipe recipe)
        {
            Console.WriteLine("Enter the number of ingredients:");
            int numIngredients = int.Parse(Console.ReadLine());
            for (int i = 0; i < numIngredients; i++)
            {
                Console.WriteLine($"Ingredient {i + 1}:");
                Console.Write("Name: ");
                string name = Console.ReadLine();
                Console.Write("Quantity: ");
                double quantity = double.Parse(Console.ReadLine());
                Console.Write("Unit: ");
                string unit = Console.ReadLine();
                Ingredient ingredient = new Ingredient
                {
                    Name = name,
                    Quantity = quantity,
                    Unit = unit
                };
                recipe.Ingredients.Add(ingredient);
            }

            // Store default quantities after entering recipe details
            recipe.StoreDefaultQuantities();

            Console.WriteLine("Enter the number of steps:");
            int numSteps = int.Parse(Console.ReadLine());
            for (int i = 0; i < numSteps; i++)
            {
                Console.WriteLine($"Enter step {i + 1}:");
                string description = Console.ReadLine();
                Step step = new Step { Description = description };
                recipe.Steps.Add(step);
            }
        }
    }
}
