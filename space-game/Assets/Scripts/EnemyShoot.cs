using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPreFab;
    public GameObject player;
    public float bulletForce = 20f;
    AudioSource shooting_audio;
    void Start(){
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        Vector2 dir = player.GetComponent<Transform>().position - gameObject.GetComponent<Transform>().position;
        rb.rotation = Mathf.Atan2(dir.y, dir.x)*Mathf.Rad2Deg - 90f;
        shooting_audio = GetComponent<AudioSource>();
        Invoke("Shoot",0.2f);
    }
    void Shoot(){
        Destroy(GetComponent<Rigidbody2D>());
        GameObject bullet = Instantiate(bulletPreFab,firePoint.position,firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        firePoint.Rotate(0,0,90f);
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        firePoint.Rotate(0,0,-90f);
        shooting_audio.Play();
    }
}
