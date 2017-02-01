using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelActivator : MonoBehaviour
{
    private static bool isActive = false;
    public static bool IsActive
    {
        get { return isActive; }
        set
        {
            isActive = value;
            currentPanel.SetActive(isActive);
        }
    }
    public GameObject panelToActivate;
    public static GameObject currentPanel;

    public void ActivatePanel()
    {
        if (panelToActivate)
        {
            currentPanel = panelToActivate;
        }
        IsActive = true;
    }
    public void ChangeState()
    {
        currentPanel = panelToActivate;
        IsActive = !IsActive;
    }
    public void DeactivatePanel()
    {
        IsActive = false;
    }
    public static void DeactivateCurrentPanel()
    {
        IsActive = false;
    }
}
