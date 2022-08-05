using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] AudioMixer mixer;
    [SerializeField] Slider musicSlider;
    [SerializeField] Slider clickSfxSlider;
    [SerializeField] Slider shootSfxSlider;
    [SerializeField] Slider deathSfxSlider;
    public float musicVolume;
    public float clickVolume;
    public float shootVolume;
    public float deathVolume;
    public bool muted;
    public const string MIXER_MUSIC =  "MusicVolume";
    public const string MIXER_SHOOT =  "ShootVolume";
    public const string MIXER_CLICK =  "ClickVolume";
    public const string MIXER_DEATH =  "DeathVolume";
    bool started = true;
    public bool saveable = false;
    private void Awake(){
         if(SaveSystem.LoadAudio() == null){
            musicVolume = 1f;
            clickVolume = 1f;
            shootVolume = 1f;
            deathVolume = 1f;
            muted = false;
            SaveSystem.SaveAudio(this);
         }
        if(musicSlider != null && shootSfxSlider != null  && clickSfxSlider != null  && deathSfxSlider != null){
            musicSlider.onValueChanged.AddListener(SetMusicVolume);
            shootSfxSlider.onValueChanged.AddListener(SetShootVolume);
            clickSfxSlider.onValueChanged.AddListener(SetClickVolume);
            deathSfxSlider.onValueChanged.AddListener(setDeathVolume);
        }
    }
    void startValue(){
        musicSlider.value = SaveSystem.LoadAudio().MusicVolume;
        shootSfxSlider.value = SaveSystem.LoadAudio().ShootVolume;
        clickSfxSlider.value = SaveSystem.LoadAudio().ClickVolume;
        deathSfxSlider.value = SaveSystem.LoadAudio().DeathVolume;

        mixer.SetFloat(MIXER_MUSIC,Mathf.Log10(musicSlider.value) * 20);
        mixer.SetFloat(MIXER_SHOOT,Mathf.Log10(shootSfxSlider.value) * 20);
        mixer.SetFloat(MIXER_CLICK,Mathf.Log10(clickSfxSlider.value) * 20);
        mixer.SetFloat(MIXER_DEATH,Mathf.Log10(deathSfxSlider.value) * 20);
    }
    void SetMusicVolume(float value){
        started = false;
        musicVolume = value;
        shootVolume = SaveSystem.LoadAudio().ShootVolume;
        clickVolume = SaveSystem.LoadAudio().ClickVolume;
        deathVolume = SaveSystem.LoadAudio().DeathVolume;
        muted = SaveSystem.LoadAudio().muted;
        SaveSystem.SaveAudio(this);
        mixer.SetFloat(MIXER_MUSIC,Mathf.Log10(value) * 20);   
    }
    void SetShootVolume(float value){
        started = false;
        shootVolume = value;
        musicVolume = SaveSystem.LoadAudio().MusicVolume;
        clickVolume = SaveSystem.LoadAudio().ClickVolume;
        deathVolume = SaveSystem.LoadAudio().DeathVolume;
        muted = SaveSystem.LoadAudio().muted;
        SaveSystem.SaveAudio(this);
        mixer.SetFloat(MIXER_SHOOT,Mathf.Log10(value) * 20);
    }
    void SetClickVolume(float value){
        started = false;
        clickVolume = value;
        shootVolume = SaveSystem.LoadAudio().ShootVolume;
        musicVolume = SaveSystem.LoadAudio().MusicVolume;
        deathVolume = SaveSystem.LoadAudio().DeathVolume;
        muted = SaveSystem.LoadAudio().muted;
        SaveSystem.SaveAudio(this);
        mixer.SetFloat(MIXER_CLICK,Mathf.Log10(value) * 20);
    }
    void setDeathVolume(float value){
        started = false;
        deathVolume = value;
        shootVolume = SaveSystem.LoadAudio().ShootVolume;
        clickVolume = SaveSystem.LoadAudio().ClickVolume;
        musicVolume = SaveSystem.LoadAudio().MusicVolume;
        muted = SaveSystem.LoadAudio().muted;
        SaveSystem.SaveAudio(this);
        mixer.SetFloat(MIXER_DEATH,Mathf.Log10(value) * 20);
    }
    public void setMuted(bool mutedX){
        shootVolume = SaveSystem.LoadAudio().ShootVolume;
        clickVolume = SaveSystem.LoadAudio().ClickVolume;
        musicVolume = SaveSystem.LoadAudio().MusicVolume;
        deathVolume = SaveSystem.LoadAudio().DeathVolume;
        muted = mutedX;
        SaveSystem.SaveAudio(this);
    }
    void FixedUpdate(){
        if(SaveSystem.LoadAudio() != null){
            saveable = true;
        }
        if(started && saveable){
            startValue();
        }
    }
}
