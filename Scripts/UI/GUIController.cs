using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GUIController : SingletonRealisation<GUIController>
{
    //-- UI texts---
    private Text scoreUI;
    private Text distanceUI;
    //-- UI images---
    public Image[] bonusImageIcon = new Image[3];
    public GameObject[] prefabBonusGroups = new GameObject[3];
    public Transform bonusPanel;
    private void Start()
    {
        if (Extensions.InitComponent<Text>(ref scoreUI, tag: GameObjectsTags.SCORE_UI_tag))
        {
            BuildPlayer.Instance.gameStats.onPowerLightChanged += delegate
            {
                SetText<int>(BuildPlayer.Instance.gameStats.PowerLight, scoreUI);
            };
        }

        if (Extensions.InitComponent<Text>(ref distanceUI, tag: GameObjectsTags.DISTANCE_UI_tag))
        {
            BuildPlayer.Instance.gameStats.onMetersChange += delegate
            {
                SetText<string>(string.Format("{0:F1} m", BuildPlayer.Instance.gameStats.Meters), distanceUI);
            };
        }
    }
    public void SetText<T>(T valueToSet,Text textObject)
    {
        textObject.text = valueToSet.ToString();
    }
}
