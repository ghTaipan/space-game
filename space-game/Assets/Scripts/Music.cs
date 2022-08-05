using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    public GameObject SoundOff;
    public GameObject SoundOn;
    void Start(){
        FindObjectOfType<DoNotDestory>().SoundOff = SoundOff;
        FindObjectOfType<DoNotDestory>().SoundOn = SoundOn;
    }
    public void MusicOff(){
        FindObjectOfType<DoNotDestory>().MusicOff();
    }
    public void MusicOn(){
        FindObjectOfType<DoNotDestory>().MusicOn();
    }
}
