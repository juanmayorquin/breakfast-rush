using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private float timer = 45;
    Player player;
    private TextMeshProUGUI timerText;

    private void Start()
    {
        timer = 45;
        timerText = GetComponent<TextMeshProUGUI>();
        player = FindObjectOfType<Player>();
    }

    void Update()
    {
        timer -= Time.deltaTime;
        timerText.text = timer.ToString("f0");

        if (timer <= 0)
        {
            timer = 0;
            player.gameOver();
        }
    }
}
