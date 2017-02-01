using UnityEngine;
using System.Collections;
public class ScrollBackground : MonoBehaviour
{
    public float speed = 0.5f;
    public Vector2 offset = Vector2.zero;
    public RectTransform[] rects;
    public Measures anchorMeasures;
    private Camera cam;
    public bool needTargetToMove = false;
    private int size = 0;
    void Awake()
    {
        offset = new Vector2(0.01f * speed, 0.0f);
        cam = Camera.main;
    }
    private void Start()
    {
        size = rects.Length;
        for(int index = 0; index < size; index++)
        {
            StartCoroutine(CourotineUpdate(rects[index]));
        }
    }

    void CycleRect(RectTransform rect)
    {
        if (rect.anchorMin.x <= anchorMeasures.min && rect.anchorMax.x <= anchorMeasures.max)
        {
            rect.anchorMin = new Vector2(-anchorMeasures.max, rect.anchorMin.y);
            rect.anchorMax = new Vector2(-anchorMeasures.min, rect.anchorMax.y);
        }
    }
    void MoveRect(RectTransform rect)
    {
        if (needTargetToMove || (int)cam.velocity.x > 1)
        {
            rect.anchorMin -= offset;
            rect.anchorMax = new Vector2(rect.anchorMin.x + 1, rect.anchorMax.y);
            CycleRect(rect);
        }
    }
    IEnumerator CourotineUpdate(RectTransform rect)
    {
        while (true)
        {
            MoveRect(rect);
            yield return null;
        }
    }
}
