using UnityEngine;
using System;
using System.Collections;

[Serializable]
public class GameStats
{
    [SerializeField]
    private int powerLight = 0;
    [SerializeField]
    private float meters = 0;
    [SerializeField]
    private bool isAlive = true;
    public int PowerLight
    {
        set
        {
            if (powerLight != value)
            {
                powerLight = value;
                onPowerLightChanged();
            }
        }
        get { return powerLight; }
    }
    public float Meters
    {
        set
        {
            if (meters != value)
            {
                meters = value;
                onMetersChange();
            }
        }
        get { return meters; }
    }
    public bool IsAlive
    {
        set
        {
            if(isAlive != value)
            {
                isAlive = value;
                onIsAliveChange();
            }
        }
    }
    public event ValueChange onPowerLightChanged = delegate { };
    public event ValueChange onMetersChange = delegate { };
    public event ValueChange onIsAliveChange = delegate { };
}

public delegate void ValueChange();