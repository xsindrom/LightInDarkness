using UnityEngine;
using System.Collections;

public class LightGameObject : MonoBehaviour
{
    private const int COLOR_AMOUNT_MULTIPLER = 20;
    public int powerLight = 0;

    void OnTriggerEnter2D(Collider2D collider2d)
    {
        if (collider2d.gameObject.CompareTag("Player"))
        {
            BuildPlayer.Instance.gameStats.PowerLight += powerLight;
            
            int tempAmount = powerLight * COLOR_AMOUNT_MULTIPLER;
            Color32 tempColor = LightController.Instance.Color;
            if ((tempColor.r + tempAmount) < 255 &&
               (tempColor.g + tempAmount) < 255 &&
               (tempColor.b + tempAmount) < 255)
            {
                tempColor = new Color32((byte)(tempColor.r + tempAmount),
                                    (byte)(tempColor.g + tempAmount),
                                    (byte)(tempColor.b + tempAmount),
                                    tempColor.a);
                LightController.Instance.Color = tempColor;
            }
            if (gameObject.transform.parent)
            {
                DestroyParent dp = gameObject.transform.parent.GetComponent<DestroyParent>();
                if (dp) dp.RemoveChild(gameObject);
            }
            Destroy(gameObject);
        }
    }
}
