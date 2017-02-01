using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class BlinkText : MonoBehaviour
{
    private Text toBlink;
    public float duration = 1.0f;
    public float alpha = 1;
    private void Start()
    {
        toBlink = gameObject.GetComponent<Text>();
        toBlink.canvasRenderer.SetAlpha(0.0f);
        StartCoroutine(Blink());
    }
    private IEnumerator Blink()
    {
        while (true)
        {
            toBlink.CrossFadeAlpha(alpha, duration, false);
            yield return new WaitForSeconds(duration);
            toBlink.CrossFadeAlpha(-alpha, duration, false);
            yield return new WaitForSeconds(duration);
        }
    }
}
