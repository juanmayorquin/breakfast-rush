using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private float timer = 45;
    Player player;
    private TextMeshProUGUI timerText;
    public bool isRunning;

    private void Start()
    {
        isRunning = false;
        timer = 0.001f;
        timerText = GetComponent<TextMeshProUGUI>();
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }

    void Update()
    {
        if (isRunning)
        {
            timer -= Time.deltaTime;
        }

        timerText.text = timer.ToString("f0");

        if (timer <= 0)
        {
            timer = 0;
            player.gameOver();
        }
    }

    public void timerStart()
    {
        timer = 45;
        isRunning = true;
    }

    public void Restart()
    {
        isRunning = false;
        timer = 45;
        player.Restart();
    }
}
