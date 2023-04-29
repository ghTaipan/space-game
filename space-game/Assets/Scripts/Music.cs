using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    public GameObject SoundOff;
    public GameObject SoundOn;
    private void Start(){
        FindObjectOfType<DoNotDestory>().SoundOff = SoundOff;
        FindObjectOfType<DoNotDestory>().SoundOn = SoundOn;
    }
    private void MusicOff(){
        FindObjectOfType<DoNotDestory>().MusicOff();
    }
    private void MusicOn(){
        FindObjectOfType<DoNotDestory>().MusicOn();
    }
}
