using UnityEngine;
using System.Collections;
public class MeterCounter : MonoBehaviour
{
    private GameStats gameStats;
    private Transform transformer;

    public void Init(GameStats gameStats, Transform transformer)
    {
        this.gameStats = gameStats;
        this.transformer = transformer;
        StartCoroutine(MeterCounting());
    }
    private IEnumerator MeterCounting()
    {
        while (true)
        {
            gameStats.Meters = transformer.position.x;
            yield return new WaitForSeconds(0.2f);
        }
    }
}
