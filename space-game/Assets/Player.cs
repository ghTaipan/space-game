using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject deathEffect;
    public virtual void Die()
    {
        GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect,0.3f);
        Destroy(gameObject);
        Destroy(FindObjectOfType<WeaponMovement>().gameObject);
    }
    public virtual void OnCollisionEnter2D(Collision2D collisionInfo ){
        if(collisionInfo.collider.tag == "Enemy"){
            Rigidbody2D rb1 = FindObjectOfType<GameManager>().enemy1.GetComponent(typeof (Rigidbody2D)) as Rigidbody2D;
            Rigidbody2D rb2 = FindObjectOfType<GameManager>().enemy2.GetComponent(typeof (Rigidbody2D)) as Rigidbody2D;
            Rigidbody2D rb3 = FindObjectOfType<GameManager>().enemy3.GetComponent(typeof (Rigidbody2D)) as Rigidbody2D;
            rb1.velocity *= 0;
            rb2.velocity *= 0;
            rb3.velocity *= 0;
            Die();
            FindObjectOfType<GameManager>().LevelFailed();
        }
    }   
}
