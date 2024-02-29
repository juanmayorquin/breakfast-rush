using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private List<GameObject> foodRecipes;
    public GameObject order;

    [SerializeField] private SpriteRenderer orderGUI;

    [SerializeField] private TextMeshProUGUI scoreText;


    public int score;
    public string playerName;

    // Start is called before the first frame update
    void Start()
    {
        orderGUI.sprite = null;
        order = foodRecipes[Random.Range(0, foodRecipes.Count)];

        playerName = "";
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        orderGUI.sprite = order.GetComponent<SpriteRenderer>().sprite;
        scoreText.text = score.ToString();
    }

    public void saveName(string playerName)
    {
        this.playerName = playerName;
    }

    public void earnPoints(int points)
    {
        score += points;
        Debug.Log(score);
    }

    public void generateNewOrder()
    {
        order = foodRecipes[Random.Range(0, foodRecipes.Count)];
        //Debug.Log(order.name);
    }

    public void gameOver()
    {
        Leaderboard.currentPlayerScore = score;
        Leaderboard.savePlayer();
        UnityEngine.SceneManagement.SceneManager.LoadScene("Final");
    }

}