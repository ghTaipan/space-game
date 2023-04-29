using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class AudioData
{
    public float MusicVolume;
    public float ClickVolume;
    public float ShootVolume;
    public float DeathVolume;
    public bool muted;

 public AudioData(VolumeSettings AudioSettings){
    MusicVolume = AudioSettings.MusicVolume;
    ClickVolume = AudioSettings.ClickVolume;
    ShootVolume = AudioSettings.ShootVolume;
    DeathVolume = AudioSettings.DeathVolume;
    muted = AudioSettings.Muted;
    }   
}
