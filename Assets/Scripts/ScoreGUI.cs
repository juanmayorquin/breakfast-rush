using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreGUI : MonoBehaviour
{

    private TextMeshProUGUI scoreText;
    [SerializeField] private GameObject newRecordText;

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
        if (newRecordText != null)
        {
            newRecordText.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = Leaderboard.currentPlayerScore.ToString();
        if (newRecordText != null)
        {
            if (Leaderboard.currentPlayerScore > Leaderboard.PlayerList[0].score)
            {
                newRecordText.SetActive(true);
            }
        }
    }
}
