using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class Shooting : MonoBehaviour
{
    
    public Transform firePoint;
    public GameObject bulletPreFab;

    public GameObject[] ammo;
    public WeaponMovement movement;
    public float bulletForce = 20f;
    public int ammoCount = 4;
    public int index = 0;
    AudioSource shooting_audio;
    void Start(){
        ammo = GameObject.FindGameObjectsWithTag("Ammo");
        SortArray(ammo);
        shooting_audio = GetComponent<AudioSource>();
    }
    void SortArray(GameObject[] ammo){
        GameObject temp;
        for(int i = 0 ; i< ammo.Length-1; i++){
            if(string.Compare(ammo[i].name,ammo[i+1].name) > 0 ){
                temp = ammo[i+1];
                ammo[i+1] = ammo[i];
                ammo[i] = temp;
                SortArray(ammo);
            }
        }
    }
    void Update()
    {
        if(Input.GetButtonDown("Fire1") && ammoCount > 0){
            if(EventSystem.current.currentSelectedGameObject == null || EventSystem.current.currentSelectedGameObject.tag != "SoundButton"){
                PlaySound();
                Shoot();
                ammo[index].SetActive(false);
                index ++;
                ammoCount --;
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
    void FixedUpdate(){
         if(ammoCount <= 0){
                movement.enabled = false;
                FindObjectOfType<GameManager>().LevelFailed();
                enabled = false;
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
