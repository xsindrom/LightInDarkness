using UnityEngine;
using System.Collections;

public class SinusoidTraectory : MonoBehaviour, ITraectory
{
    public float a = 1.0f;
    public float X { get { return 1.0f; } }
    public float Y { get { return Mathf.Sin(a * Time.time); } }
}
