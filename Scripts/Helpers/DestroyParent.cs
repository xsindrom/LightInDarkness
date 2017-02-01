using UnityEngine;
using System.Collections.Generic;

public class DestroyParent : MonoBehaviour {

    public List<GameObject> childs;
    private Transform transformer;

    public int minimumChildSizeToDestroy = 1;
    void Start()
    {
        transformer = transform;
        childs = new List<GameObject>(transformer.GetChilds());
    }
    public void RemoveChild(GameObject child)
    {
        if (childs.Contains(child))
        {
            childs.Remove(child);
            if (childs.Count == minimumChildSizeToDestroy)
            {
                Destroy(transformer.gameObject);
            }
        }
    }
}
