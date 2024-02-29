using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    private string playerName;

    public void startGame()
    {
        savePlayerName();
        loadScene("Game");
    }
    private void savePlayerName()
    {
        playerName = GameObject.Find("InputField").GetComponent<UnityEngine.UI.InputField>().text;
        Leaderboard.currentPlayerName = playerName;
    }

    public void loadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
