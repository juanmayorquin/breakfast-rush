using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeManager : MonoBehaviour
{
    public List<FoodRecipe> FoodRecipes;
    public GameObject FindRecipeResult(FoodItem item1, FoodItem item2)
    {
        GameObject result = null;
        foreach (var recipe in FoodRecipes)
        {
            if (((recipe.recipe[0].GetComponent<FoodItem>().foodName.Equals(item1.foodName) && recipe.recipe[1].GetComponent<FoodItem>().foodName.Equals(item2.foodName))))
            {
                result = recipe.result;
            }
        }
        return result;
    }
}
