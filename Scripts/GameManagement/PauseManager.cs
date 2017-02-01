﻿using UnityEngine;

public static class PauseManager
{
    public static void PauseGame()
    {
        Time.timeScale = 0.0f;
    }
    public static void UnPauseGame()
    {
        Time.timeScale = 1.0f;
    }
}
