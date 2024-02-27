using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int score;
    public string playerName;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void saveName(string playerName)
    {
        this.playerName = playerName;
    }

    public void earnPoints(int points)
    {
        score += points;
    }
}
