using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SettingsPanelScript : MonoBehaviour
{
    public Image soundFillerImage;
    private void Awake()
    {
        if (!File.Exists(Application.persistentDataPath + GameConstants.CONFIG_Path))
        {
            File.Create(Application.persistentDataPath + GameConstants.CONFIG_Path);
        }
    }
    private void Start()
    {
        FillImage();
    }
    public void FillImage()
    {
        soundFillerImage.fillAmount = AudioListener.volume;
    }
    public void OnIncreaseVolumeButtonClick()
    {
        SoundSettings.IncreaseVolume();
    }
    public void OnDeacreaseVolumeButtonClick()
    {
        SoundSettings.DecreaseVolume();
    }
    public void OnMuteButtonClick()
    {
        SoundSettings.Mute();
    }
    private void SetVolume()
    {
        SoundSettings.Volume = PlayerPrefs.GetFloat("Volume");
    }
    private void OnEnable()
    {
        SoundSettings.onVolumeChange += FillImage;
        string jData = File.ReadAllText(Application.persistentDataPath + GameConstants.CONFIG_Path);
        SoundSettingsToSave toGet = JsonUtility.FromJson<SoundSettingsToSave>(jData);
        SoundSettings.Volume = (float)toGet.Volume;
    }
    private void OnDisable()
    {
        SoundSettings.onVolumeChange -= FillImage;
        SoundSettingsToSave toSave = new SoundSettingsToSave() { Volume = SoundSettings.Volume };
        string jData = JsonUtility.ToJson(toSave);
        File.WriteAllText(Application.persistentDataPath + GameConstants.CONFIG_Path, jData);
    }
}
public class SoundSettingsToSave
{
    public double Volume;
}