using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    private string playerName;

    public void startGame(TextMeshProUGUI playerInput)
    {
        savePlayerName(playerInput.text);
        loadScene("Instrucciones");
    }
    private void savePlayerName(string playerName)
    {
        this.playerName = playerName;
        Leaderboard.currentPlayerName = playerName;
    }

    public void loadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
