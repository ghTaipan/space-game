using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
public class DoNotDestory : MonoBehaviour
{
    public static DoNotDestory instance;
    public AudioClip music2;
    public AudioClip music3;
    public AudioClip music4;
    public AudioClip music5;
    public GameObject SoundOff;
    public GameObject SoundOn;
    public bool nextMusic = false;
    bool muted;
    public int levelNumber = 0;
    Animator musicAnim;
    [SerializeField] AudioMixer mixer;
    float musicVolume;
    float clickVolume;
    float shootVolume;
    float deathVolume;
    const string MIXER_MUSIC =  "MusicVolume";
    const string MIXER_SHOOT =  "ShootVolume";
    const string MIXER_CLICK =  "ClickVolume";
    const string MIXER_DEATH =  "DeathVolume";
    private void Awake(){
        DontDestroyOnLoad(this.gameObject);
        musicAnim = GetComponent<Animator>();
        if(instance == null ){
            instance = this;
        }
        else{
            Destroy(gameObject);
        }
        LoadVolume();
    }
    void LoadVolume(){
        musicVolume = SaveSystem.LoadAudio().MusicVolume;
        shootVolume = SaveSystem.LoadAudio().ShootVolume;
        clickVolume = SaveSystem.LoadAudio().ClickVolume;
        deathVolume = SaveSystem.LoadAudio().DeathVolume;
        muted = SaveSystem.LoadAudio().muted;

        if(muted != false){
             gameObject.GetComponent<AudioSource>().Stop();
        }

        mixer.SetFloat(MIXER_MUSIC,Mathf.Log10(musicVolume) * 20);
        mixer.SetFloat(MIXER_SHOOT,Mathf.Log10(shootVolume) * 20);
        mixer.SetFloat(MIXER_CLICK,Mathf.Log10(clickVolume) * 20);
        mixer.SetFloat(MIXER_DEATH,Mathf.Log10(deathVolume) * 20);
    }
      
    void FixedUpdate(){
        if(SoundOn != null && SoundOff != null){
            if(muted){
                SoundOn.SetActive(true);
                SoundOff.SetActive(false);
            }
            else{
                SoundOn.SetActive(false);
                SoundOff.SetActive(true);
            }
        }
        int index = FindObjectOfType<DoNotDestory>().levelNumber;
        if(index >= 0 && index <4 && nextMusic == false && SceneManager.GetActiveScene().buildIndex != 0){
            musicAnim.SetTrigger("Switch");
            AudioSource gameMusic = gameObject.GetComponent<AudioSource>();
            nextMusic = true;
            gameMusic.clip = music2;
            if(!muted){
                gameMusic.Play();
            }
        }
        else if(index >= 4 && index < 8 &&  nextMusic == false ){
            AudioSource gameMusic = gameObject.GetComponent<AudioSource>();
            nextMusic = true;
            gameMusic.clip = music3;
            if(!muted){
                gameMusic.Play();
            }
        }
        else  if(index >= 8 && index <12 && nextMusic == false ){
            AudioSource gameMusic = gameObject.GetComponent<AudioSource>();
            nextMusic = true;
            gameMusic.clip = music4;
            if(!muted){
                gameMusic.Play();
            }
        }
        else  if(index >= 12 && FindObjectOfType<Credits>() == null && nextMusic == false ){
            AudioSource gameMusic = gameObject.GetComponent<AudioSource>();
            nextMusic = true;
            gameMusic.clip = music5;
            if(!muted){
                gameMusic.Play();
            }
        }
        else if (FindObjectOfType<Credits>() != null && FindObjectOfType<Credits>().switchToMenu == 1){
            Destroy(gameObject);
        }
    }
     public void MusicOff(){
        FindObjectOfType<VolumeSettings>().setMuted(true);
        muted = SaveSystem.LoadAudio().muted;
        gameObject.GetComponent<AudioSource>().Stop();
    }
    public void MusicOn(){
        FindObjectOfType<VolumeSettings>().setMuted(false);
        muted = SaveSystem.LoadAudio().muted;
        gameObject.GetComponent<AudioSource>().Play();
    }
}
