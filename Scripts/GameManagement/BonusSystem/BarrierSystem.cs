using UnityEngine;
using System.Collections;

public class BarrierSystem : MonoBehaviour, IBonus
{
    //Marker
    public int ID { get { return 0; } }

    public bool active = false;
    
    public void Activate()
    {
        StartCoroutine(Timer());
    }
    public IEnumerator Timer()
    {
        active = true;
        OnActivation(active);
        float temp = BuildPlayer.Instance.physicStats.height;
        BuildPlayer.Instance.physicStats.height = 0;
        yield return new WaitForSeconds(GameConstants.BONUS_TIME);
        active = false;
        OnActivation(active);
        BuildPlayer.Instance.physicStats.height = temp;
    }
    private void OnActivation(bool active)
    {
        BuildPlayer.Instance.rigidBody.isKinematic = active;
        BuildPlayer.Instance.collider.enabled = !active;
        BuildPlayer.Instance.barrierEffects.SetActive(active);
    }
}
