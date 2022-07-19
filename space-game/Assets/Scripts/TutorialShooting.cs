using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class TutorialShooting : MonoBehaviour
{
     public Transform firePoint;
    public GameObject bulletPreFab;
    public WeaponMovement movement;
    public float bulletForce = 20f;
    AudioSource shooting_audio;

    void Start(){
        shooting_audio = GetComponent<AudioSource>();
    }
    void Update()
    {
        if(Input.GetButtonDown("Fire1") ){
            if(EventSystem.current.currentSelectedGameObject == null || (EventSystem.current.currentSelectedGameObject.tag != "NextButton" 
                && EventSystem.current.currentSelectedGameObject.tag != "BackButton")){
                    PlaySound();
                    Shoot();
            }
        }
    }
        void PlaySound(){
        if(shooting_audio.isPlaying){
            shooting_audio.Stop();
            shooting_audio.Play();
        }
        else{
            shooting_audio.Play();
        }
    }
    void Shoot(){
        GameObject bullet = Instantiate(bulletPreFab,firePoint.position,firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        firePoint.Rotate(0,0,90f);
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        firePoint.Rotate(0,0,-90f);

    }
}
