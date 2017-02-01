using UnityEngine;
using System.Collections;

public static class GameObjectsTags
{
    public const string GROUND_tag = "Ground";
    public const string PLAYER_tag = "Player";
    public const string BONUS_tag = "Bonus";
    public const string SCORE_UI_tag = "ScoreUI";
    public const string DISTANCE_UI_tag = "DistanceUI";
    public const string BARRIER_UI_tag = "BarrierUI";
    public const string DOUBLESPEED_UI_tag = "DoubleSpeedUI";
    public const string CLEARVIEW_UI_tag = "ClearViewUI";
    public const string DISTANCE_UI_death_panel = "DistanceUIdeathPanel";
    public static string[] BONUS_UI_tags = { BARRIER_UI_tag, DOUBLESPEED_UI_tag, CLEARVIEW_UI_tag };
}
