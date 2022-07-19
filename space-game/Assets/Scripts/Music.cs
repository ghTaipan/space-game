using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    public GameObject SoundOff;
    public GameObject SoundOn;
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
