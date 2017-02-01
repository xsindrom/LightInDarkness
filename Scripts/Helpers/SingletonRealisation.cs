using UnityEngine;
using System.Collections;

public class SingletonRealisation<T> : MonoBehaviour where T: MonoBehaviour
{
    private static T instance;
    public static T Instance
    {
        get
        {
            if (!instance)
            {
                instance = FindObjectOfType<T>();
                if (!instance)
                {
                    instance = new GameObject().AddComponent<T>();
                }
            }
            return instance;
        }
    }
}
