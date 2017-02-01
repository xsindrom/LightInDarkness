using UnityEngine;

public class Destroyer : MonoBehaviour
{
    private Transform toDestroy = null;
    
    private void OnTriggerEnter2D(Collider2D collider2d)
    {
        toDestroy = collider2d.transform;
        toDestroy.gameObject.SetActive(false);
        if (toDestroy.parent)
        {
            DestroyParent dp = toDestroy.parent.GetComponent<DestroyParent>();
            if (dp) dp.RemoveChild(toDestroy.gameObject);
        }
        Destroy(toDestroy.gameObject);
    }
}

