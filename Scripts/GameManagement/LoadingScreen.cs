using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LoadingScrene
{
    private float loadingProgress = 0.0f;
    private GameObject loadingScreen;
    private Image progressBar;
    public void InitLoadingScreen(GameObject loadingScreen, Image progressBar)
    {
        this.loadingScreen = loadingScreen;
        this.progressBar = progressBar;
        
    }
    public IEnumerator FillProgressBar()
    {
        while (loadingProgress < 1.0f)
        {
            progressBar.fillAmount = loadingProgress;
            yield return null;
        }
    }
    public IEnumerator LoadScene(int sceneIndex)
    {
        loadingScreen.SetActive(true);
        AsyncOperation loadingScene = SceneManager.LoadSceneAsync(sceneIndex);
        while (!loadingScene.isDone)
        {
            loadingProgress = loadingScene.progress;
            yield return null;
        }
    }
}
