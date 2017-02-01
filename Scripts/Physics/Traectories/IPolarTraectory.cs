using UnityEngine;
using System;
public interface IPolarTraectory: ITraectory
{
    float R { get; }
    float F { get; }
}
