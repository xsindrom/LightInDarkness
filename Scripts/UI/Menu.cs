using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{
    public float loadingProgress = 0.0f;
    public GameObject loadingScreen;
    public Image progressBar;


    private void Awake()
    {
        UserStats.Instance.Init();
    }

    public void OnQuitGameButtonClick()
    {
        Application.Quit();
    }
    public void OnStartGameButtonClick()
    {
        LoadingScrene loadingScreen = new LoadingScrene();
        loadingScreen.InitLoadingScreen(this.loadingScreen, progressBar);
        StartCoroutine(loadingScreen.LoadScene(1));
        StartCoroutine(loadingScreen.FillProgressBar());
    }
    public void OnRefreshButtonClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void OnHomeButtonClick()
    {
        SceneManager.LoadScene(0);
    }
    public void OnRateButtonClick()
    {
        Application.OpenURL("https://play.google.com/store/apps/details?id=com.XsindromCompany.LightInDarkness");
    }

    public void OnLeadersButtonClick()
    {
        LeadersSystem.ShowLeaders();
    }
    public void OnPauseButtonClick()
    {
        PauseManager.PauseGame();
    }
    public void OnContinueButtonClick()
    {
        PauseManager.UnPauseGame();
    }
}
