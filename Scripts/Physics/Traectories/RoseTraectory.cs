using UnityEngine;
using System;
[Serializable]
public class RoseTraectory : MonoBehaviour, IPolarTraectory
{
    public int petalSize = 2;

    public float F { get { return Time.time; } }
    public float R { get { return Mathf.Sin(petalSize * F); } }
    public float Y { get { return R * Mathf.Sin(F); } }
    public float X { get { return R * Mathf.Cos(F); } }
}
