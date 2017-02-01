using UnityEngine;
using System.Collections;

public class CosinusoidTraectory : MonoBehaviour, ITraectory
{
    public float a = 1;
    public float X { get { return 1.0f; } }
    public float Y { get { return Mathf.Cos(a * Time.time); } }
}
