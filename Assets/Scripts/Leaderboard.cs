using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Leaderboard
{
    public static List<Player> PlayerList = new List<Player>();
    public static string currentPlayerName = "";
    public static int currentPlayerScore = 0;

    public static void savePlayer(Player player)
    {
        int index = PlayerList.FindIndex(p => p.score <= player.score);

        if (index == -1)
        {
            PlayerList.Add(player);
        }
        else
        {
            PlayerList.Insert(index, player);
        }
    }

}
