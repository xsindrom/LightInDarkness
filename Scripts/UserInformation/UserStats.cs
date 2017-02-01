using UnityEngine;
using System;
using System.Collections;
using UnityEngine.SocialPlatforms;
using GooglePlayGames;

public class UserStats : SingletonRealisation<UserStats>
{
    public void Init()
    {
        PlayGamesPlatform.DebugLogEnabled = true;
        PlayGamesPlatform.Activate();
        Social.localUser.Authenticate((bool success) => { });
        if (!PlayerPrefs.HasKey("Lights"))
        {
            PlayerPrefs.SetInt("Lights", 0);
        }
    }
    public void SaveCurrency()
    {
        PlayerPrefs.SetInt("Lights", PlayerPrefs.GetInt("Lights") + BuildPlayer.Instance.gameStats.PowerLight);
    }
}
