using UnityEngine;
using System;
[Serializable]
public class CircleTraectory : MonoBehaviour, IPolarTraectory
{
    public float F { get { return Time.time; } }
    public float R { get { return 1.0f; } }
    public float Y { get { return R * Mathf.Sin(F); } }
    public float X { get { return R * Mathf.Cos(F); } }
}
