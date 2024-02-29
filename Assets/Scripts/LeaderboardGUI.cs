using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LeaderboardGUI : MonoBehaviour
{
    [SerializeField] private List<TextMeshProUGUI> names;
    [SerializeField] private List<TextMeshProUGUI> scores;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < Leaderboard.PlayerList.Count; i++)
        {
            if(i > 5)
            {
                i = 5;
                break;
            }
            names[i].text = Leaderboard.PlayerList[i].playerName;
            scores[i].text = Leaderboard.PlayerList[i].score.ToString();
        }   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
