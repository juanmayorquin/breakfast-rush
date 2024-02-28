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
            if (((recipe.recipe[0].Equals(item1) && recipe.recipe[1].Equals(item2)) ||
                (recipe.recipe[0].Equals(item2)  && recipe.recipe[1].Equals(item1))))
            {
                result = recipe.result;
            }
        }
        return result;
    }
}
