using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodRecipe : MonoBehaviour
{
    public FoodItem[] recipe = new FoodItem[2];
    public GameObject result;

    public FoodRecipe(FoodItem item1, FoodItem item2)
    {
        this.recipe[0] = item1;
        this.recipe[1] = item2;
    }
}
