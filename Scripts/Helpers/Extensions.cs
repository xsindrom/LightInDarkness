using UnityEngine;
using System.Collections;

public static class Extensions
{
    public static bool MoreEqual(this Vector3 firstVector, Vector3 secondVector)
    {
        return (firstVector.x >= secondVector.x && firstVector.y >= secondVector.y) ? true : false;
    }
    public static GameObject[] GetChilds(this Transform parent)
    {
        int size = parent.childCount;
        GameObject[] toReturn = new GameObject[size];
        for (int index = 0; index < size; index++)
        {
            toReturn[index] = parent.GetChild(index).gameObject;
        }
        return toReturn;
    }
    public static bool InitComponent<T>(ref T componentToInit, string tag) where T : MonoBehaviour
    {
        GameObject componentToInitGameObject = GameObject.FindGameObjectWithTag(tag);
        if (componentToInitGameObject)
        {
            componentToInit = componentToInitGameObject.GetComponent<T>();
        }
        return componentToInit;
    }
    public static T InitComponent<T>(this T componentToInit, string tag) where T : MonoBehaviour
    {
        GameObject componentToInitGameObject = GameObject.FindGameObjectWithTag(tag);
        if (componentToInitGameObject)
        {
            componentToInit = componentToInitGameObject.GetComponent<T>();
        }
        return componentToInit;
    }
}
