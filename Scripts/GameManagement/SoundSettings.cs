using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SoundSettings
{
    public static event ValueChange onVolumeChange = delegate { };
    public static float Volume
    {
        get { return AudioListener.volume; }
        set
        {
            if(value != AudioListener.volume)
            {
                AudioListener.volume = value;
                onVolumeChange();
            }
        }
    }
    public static void IncreaseVolume()
    {
        if (Volume < 1.0f)
        {
            Volume += GameConstants.SOUND_VOLUME_point;
        }
    }
    public static void DecreaseVolume()
    {
        if (Volume > GameConstants.SOUND_VOLUME_point)
        {
            Volume -= GameConstants.SOUND_VOLUME_point;
        }
    }
    public static void Mute()
    {
        Volume = 0.0f;
    }
}
