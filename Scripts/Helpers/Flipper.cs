using UnityEngine;
using System;

[Serializable]
public class Flipper
{
    public bool needFlipX = false;
    public bool needFlipY = false;
    [NonSerialized]
    public SpriteRenderer render;

    public void FlipX()
    {
        if (needFlipX) { render.flipX = !render.flipX; }
    }
    public void FlipY()
    {
        if (needFlipY) { render.flipY = !render.flipY; }
    }
}
