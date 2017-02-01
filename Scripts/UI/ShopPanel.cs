using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

using LitJson;
public class ShopPanel : MonoBehaviour
{
    public HeroData[] heroData;

    public Sprite[] heroIcons;
    public RuntimeAnimatorController[] heroAnimators;
    
    private void Start()
    {
        string jsonData = Resources.Load<TextAsset>("Heros").text;
        heroData = JsonMapper.ToObject<HeroData[]>(jsonData);
        heroAnimators = new RuntimeAnimatorController[heroData.Length];
        heroIcons = new Sprite[heroData.Length];
        for (int index = 0, size = heroData.Length; index < size; index++)
        {
            heroAnimators[index] = Resources.Load<RuntimeAnimatorController>(heroData[index].animator_path);
            heroIcons[index] = Resources.Load<Sprite>(heroData[index].image_path);
        }
    }
}
[Serializable]
public class HeroData
{
    [SerializeField]
    public int id;
    [SerializeField]
    public string name;
    [SerializeField]
    public string image_path;
    [SerializeField]
    public string animator_path;
}
