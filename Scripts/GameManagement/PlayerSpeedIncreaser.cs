using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpeedIncreaser:MonoBehaviour
{
    public void Init()
    {
        StartCoroutine(IncreaseSpeed());
    }
    private IEnumerator IncreaseSpeed()
    {
        while (true)
        {
            yield return new WaitForSeconds(GameConstants.SPEED_INCREASE_TIME);
            BuildPlayer.Instance.physicStats.speed++;
        }
    }
}
