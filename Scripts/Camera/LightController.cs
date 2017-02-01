using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LightController : SingletonRealisation<LightController>
{
    public Image[] spritesToColor;
    public float speed = 1.0f;

    private Color32 color = new Color32(254, 254, 254, 254);
    public Color32 Color
    {
        get { return color; }
        set
        {
            color = value;
            onColorAmountChange();
        }
    }
    public event ValueChange onColorAmountChange = delegate { };

    private void Start()
    {
        StartCoroutine(ReduceColorAmount());
        if (spritesToColor.Length != 0)
        {
            onColorAmountChange = ChangeColor;
        }
    }
    private void ChangeColor()
    {
        for (int index = 0, size = spritesToColor.Length; index < size; index++) 
        {
            spritesToColor[index].color = Color;
        }
    }
    public IEnumerator ReduceColorAmount()
    {
        while (true)
        {
            if (Color.r - 1 > 1)
            {
                Color = new Color32((byte)(Color.r - 1), (byte)(Color.g - 1), (byte)(Color.b - 1), Color.a);
            }
            yield return new WaitForSeconds(1.0f / speed);
        }
    }
}
