using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Leaderboard
{
    public static List<Player> PlayerList = new List<Player>();

    public static void addPlayer(Player player)
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
