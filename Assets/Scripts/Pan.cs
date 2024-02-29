using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pan : MonoBehaviour
{
    private Player player;

    private void Start()
    {
        player = FindObjectOfType<Player>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<FoodItem>() && collision.GetComponent<FoodItem>().isRecipe)
        {
            if (collision.GetComponent<FoodItem>().foodName.Equals(player.order.GetComponent<FoodItem>().foodName))
            {
                player.generateNewOrder();
                player.earnPoints(50);                
            }
            Destroy(collision.gameObject);
        }
    }
}
