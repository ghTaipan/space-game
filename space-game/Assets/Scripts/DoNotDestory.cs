using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
    Animator musicAnim;
    private void Awake(){
        DontDestroyOnLoad(this.gameObject);
        musicAnim = GetComponent<Animator>();
        if(instance == null ){
            instance = this;
        }
        else{
            Destroy(gameObject);
        }
    } 
    void FixedUpdate(){
        int index = SceneManager.GetActiveScene().buildIndex;
        if(index >= 1 && index <5 && nextMusic == false ){
            musicAnim.SetTrigger("Switch");
            AudioSource gameMusic = gameObject.GetComponent<AudioSource>();
            nextMusic = true;
            gameMusic.clip = music2;
            gameMusic.Play();
        }
        else if(index >= 5 && index < 9 &&  nextMusic == false ){
            AudioSource gameMusic = gameObject.GetComponent<AudioSource>();
            nextMusic = true;
            gameMusic.clip = music3;
            gameMusic.Play();
        }
        else  if(index >= 9 && index <13 && nextMusic == false ){
            AudioSource gameMusic = gameObject.GetComponent<AudioSource>();
            nextMusic = true;
            gameMusic.clip = music4;
            gameMusic.Play();
        }
        else  if(index >= 13 && FindObjectOfType<Credits>() == null && nextMusic == false ){
            AudioSource gameMusic = gameObject.GetComponent<AudioSource>();
            nextMusic = true;
            gameMusic.clip = music5;
            gameMusic.Play();
        }
        else if (FindObjectOfType<Credits>() != null && FindObjectOfType<Credits>().switchToMenu == 1){
            Destroy(gameObject);
        }
    }
     public void MusicOff(){
        FindObjectOfType<DoNotDestory>().gameObject.GetComponent<AudioSource>().Stop();
        SoundOff.SetActive(false);
        SoundOn.SetActive(true);
    }
    public void MusicOn(){
        FindObjectOfType<DoNotDestory>().gameObject.GetComponent<AudioSource>().Play();
        SoundOff.SetActive(true);
        SoundOn.SetActive(false);
    }
}
