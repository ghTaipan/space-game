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
    MusicVolume = AudioSettings.musicVolume;
    ClickVolume = AudioSettings.clickVolume;
    ShootVolume = AudioSettings.shootVolume;
    DeathVolume = AudioSettings.deathVolume;
    muted = AudioSettings.muted;
    }   
}
