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
        public int Calories { get; set; } // Number of calories
        public string FoodGroup { get; set; } // Food group the ingredient belongs to
    }

    // Represents a step in a recipe
    class Step
    {
        public string Description { get; set; } // Description of the step
    }

    // Represents a recipe consisting of ingredients and steps
    class Recipe
    {
        public string Name { get; set; } // Name of the recipe
        public List<Ingredient> Ingredients { get; set; } // List of ingredients in the recipe
        public List<Step> Steps { get; set; } // List of steps in the recipe

        // Constructor to initialize lists
        public Recipe(string name)
        {
            Name = name;
            Ingredients = new List<Ingredient>();
            Steps = new List<Step>();
        }

        // Display the recipe including ingredients and steps
        public void DisplayRecipe()
        {
            Console.WriteLine($"\nRecipe: {Name}");
            Console.WriteLine("Ingredients:");
            foreach (Ingredient ingredient in Ingredients)
            {
                Console.WriteLine($"- {ingredient.Quantity} {ingredient.Unit} of {ingredient.Name}, {ingredient.Calories} calories, Food group: {ingredient.FoodGroup}");
            }
            Console.WriteLine("\nSteps:");
            foreach (Step step in Steps)
            {
                Console.WriteLine($"- {step.Description}");
            }
        }

        // Calculate and return the total calories of all ingredients
        public int TotalCalories()
        {
            int totalCalories = 0;
            foreach (Ingredient ingredient in Ingredients)
            {
                totalCalories += ingredient.Calories;
            }
            return totalCalories;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Recipe> recipes = new List<Recipe>(); // Create a list to store recipes
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
                        EnterRecipeDetails(recipes); // Call function to enter recipe details
                        break;
                    case 2:
                        DisplayRecipeList(recipes); // Display list of recipes
                        break;
                    case 3:
                        // Implement scaling recipe
                        break;
                    case 4:
                        // Implement resetting quantities
                        break;
                    case 5:
                        recipes.Clear(); // Clear all recipe data
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
        static void EnterRecipeDetails(List<Recipe> recipes)
        {
            Console.WriteLine("Enter the name of the recipe:");
            string name = Console.ReadLine();
            Recipe recipe = new Recipe(name); // Create a new recipe instance

            Console.WriteLine("Enter the number of ingredients:");
            int numIngredients = int.Parse(Console.ReadLine());

            for (int i = 0; i < numIngredients; i++)
            {
                Console.WriteLine($"Ingredient {i + 1}:");
                Console.Write("Name: ");
                string ingredientName = Console.ReadLine();
                Console.Write("Quantity: ");
                double quantity = double.Parse(Console.ReadLine());
                Console.Write("Unit: ");
                string unit = Console.ReadLine();
                Console.Write("Calories: ");
                int calories = int.Parse(Console.ReadLine());
                Console.Write("Food group: ");
                string foodGroup = Console.ReadLine();

                Ingredient ingredient = new Ingredient
                {
                    Name = ingredientName,
                    Quantity = quantity,
                    Unit = unit,
                    Calories = calories,
                    FoodGroup = foodGroup
                };
                recipe.Ingredients.Add(ingredient); // Add the ingredient to the list
            }

            Console.WriteLine("Enter the number of steps:");
            int numSteps = int.Parse(Console.ReadLine());

            for (int i = 0; i < numSteps; i++)
            {
                Console.WriteLine($"Enter step {i + 1}:");
                string description = Console.ReadLine();
                Step step = new Step { Description = description };
                recipe.Steps.Add(step); // Add the step to the list
            }

            recipes.Add(recipe); // Add the recipe to the list
        }

        // Function to display list of recipes
        static void DisplayRecipeList(List<Recipe> recipes)
        {
            Console.WriteLine("List of Recipes:");
            recipes.Sort((x, y) => string.Compare(x.Name, y.Name)); // Sort recipes alphabetically by name
            foreach (Recipe recipe in recipes)
            {
                Console.WriteLine(recipe.Name);
            }

            Console.WriteLine("Enter the name of the recipe to display:");
            string recipeName = Console.ReadLine();
            Recipe selectedRecipe = recipes.Find(recipe => recipe.Name == recipeName);
            if (selectedRecipe != null)
            {
                selectedRecipe.DisplayRecipe();
            }
            else
            {
                Console.WriteLine("Recipe not found.");
            }
        }
    }
}
