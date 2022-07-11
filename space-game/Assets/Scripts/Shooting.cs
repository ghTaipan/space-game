using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Shooting : MonoBehaviour
{
    
    public Transform firePoint;
    public GameObject bulletPreFab;

    public GameObject[] ammo;
    public WeaponMovement movement;
    public float bulletForce = 20f;
    public int ammoCount = 4;
    int index = 0;
    void Start(){
        ammo = GameObject.FindGameObjectsWithTag("Ammo");
        SortArray(ammo);
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
            Shoot();
            Destroy(ammo[index]);
            index ++;
            ammoCount --;
            if(ammoCount <= 0){
                movement.enabled = false;
                FindObjectOfType<GameManager>().LevelFailed();
            }
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
