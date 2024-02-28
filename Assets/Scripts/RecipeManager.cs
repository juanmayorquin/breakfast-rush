using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeManager : MonoBehaviour
{
    public List<FoodRecipe> FoodRecipes;
    public FoodItem FindRecipeResult(FoodItem item1, FoodItem item2)
    {
        FoodItem result = null;
        foreach (var recipe in FoodRecipes)
        {
            if (((recipe.recipe[0].foodName.Equals(item1.foodName) && recipe.recipe[1].foodName.Equals(item2.foodName)) ||
                (recipe.recipe[0].foodName.Equals(item2.foodName)  && recipe.recipe[1].foodName.Equals(item1.foodName))))
            {
                result = recipe.result;
            }
        }
        return result;
    }
}
