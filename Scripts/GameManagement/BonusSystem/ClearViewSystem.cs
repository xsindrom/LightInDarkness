using UnityEngine;
using System.Collections;

public class ClearViewSystem : MonoBehaviour, IBonus
{
    //Marker
    public int ID { get { return 2; } }

    public void Activate()
    {
        StartCoroutine(Timer());
    }
    public IEnumerator Timer()
    {
        float tempTime = GameConstants.BONUS_TIME; 
        Color tempColor = LightController.Instance.Color;
        while (tempTime > 0.0f)
        {
            tempTime -= Time.deltaTime;
            LightController.Instance.Color = Color.white;
            yield return null;
        }
        LightController.Instance.Color = tempColor;
    }
}
