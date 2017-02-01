using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
public class DeathPanelScript : MonoBehaviour
{
    public GameObject deathPanel;
    public Text distanceUI;
    public Text console;
    private void Start()
    {
        BuildPlayer.Instance.gameStats.onIsAliveChange += FillInformation;
        BuildPlayer.Instance.gameStats.onIsAliveChange += delegate { StartCoroutine(ActivateDeathPanel()); };
    }
    private void FillInformation()
    {
        if (Social.localUser.authenticated)
        {
            FillText();
        }
        else
        {
            distanceUI.text = "Connect to network";
        }
    }
    private void FillText()
    {
        PlayGamesPlatform.Instance.LoadScores(
            LightInDarknessResources.leaderboard_light_in_darkness_leaders,
            LeaderboardStart.TopScores,
            1,
            LeaderboardCollection.Public,
            LeaderboardTimeSpan.Weekly,
            (data) =>
            {
                if (BuildPlayer.Instance.gameStats.Meters > data.Scores[0].value)
                {
                    distanceUI.text = string.Format("High score: {0:F1} m", BuildPlayer.Instance.gameStats.Meters);
                }
                else
                {
                    distanceUI.text = string.Format("{0:F1} m", BuildPlayer.Instance.gameStats.Meters);
                }
            });
    }
    private IEnumerator ActivateDeathPanel()
    {
        yield return new WaitForSeconds(GameConstants.DEATH_TIME);
        PauseManager.PauseGame();
        deathPanel.SetActive(true);
    }
    private void OnDisable()
    {
        PauseManager.UnPauseGame();
    }
}
