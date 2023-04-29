using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipParrent : MonoBehaviour
{
    public GameObject deathEffect;
    public GameObject deathSound;
    public virtual void Die()
    {
        GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
        Instantiate(deathSound,transform.position, Quaternion.identity);
        Destroy(effect,0.3f);
        Destroy(gameObject);
    }
    protected virtual void OnCollisionEnter2D(Collision2D collisionInfo ){
        if(collisionInfo.collider.tag == "Bullet"){
            Die();
            Destroy(collisionInfo.collider.gameObject);
        }
    }
}
