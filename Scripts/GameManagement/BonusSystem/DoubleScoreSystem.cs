using UnityEngine;
using System.Collections;

public class DoubleScoreSystem : MonoBehaviour, IBonus
{
    //Marker
    public int ID { get { return 1; } }

    public void Activate()
    {
        StartCoroutine(Timer());
    }
    public IEnumerator Timer()
    {
        BuildPlayer.Instance.physicStats.speed *= GameConstants.BONUS_SPEED;
        yield return new WaitForSeconds(GameConstants.BONUS_TIME);
        BuildPlayer.Instance.physicStats.speed /= GameConstants.BONUS_SPEED;
    }
}
