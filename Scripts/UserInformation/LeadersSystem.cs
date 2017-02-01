using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
public static class LeadersSystem
{
    public static void ShowLeaders()
    {
        if (Social.localUser.authenticated)
        {
            Social.ShowLeaderboardUI();
        }
    }
    public static void ReportLeader()
    {
        Social.ReportScore((long)BuildPlayer.Instance.gameStats.Meters,
                           LightInDarknessResources.leaderboard_light_in_darkness_leaders,
                           null);
    }
}
