using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class TutorialShooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPreFab;
    private WeaponMovement movement;
    private float bulletForce = 20f;
    AudioSource shooting_audio;

    private void Start(){
        shooting_audio = GetComponent<AudioSource>();
    }
    private void Update()
    {
        if(Input.GetButtonDown("Fire1") ){
            if(EventSystem.current.currentSelectedGameObject == null || (EventSystem.current.currentSelectedGameObject.tag != "Button")){
                    PlaySound();
                    Shoot();
            }
        }
    }
    private void PlaySound(){
        if(shooting_audio.isPlaying){
            shooting_audio.Stop();
            shooting_audio.Play();
        }
        else{
            shooting_audio.Play();
        }
    }
    private void Shoot(){
        GameObject bullet = Instantiate(bulletPreFab,firePoint.position,firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        firePoint.Rotate(0,0,90f);
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        firePoint.Rotate(0,0,-90f);

    }
}
