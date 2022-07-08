using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    
    public Transform firePoint;
    public GameObject bulletPreFab;
    public WeaponMovement movement;
    public float bulletForce = 20f;
    public float ammo = 4f;
    void Update()
    {
        if(Input.GetButtonDown("Fire1") && ammo > 0){
            Shoot();
            ammo --;
            if(ammo <= 0){
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
