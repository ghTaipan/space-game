using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject deathEffect;
    private Animator playerAnimator;
    void Start(){
        playerAnimator = GetComponent<Animator>();
        playerAnimator.SetTrigger("TriEnter");
    }
    public void Exit(){
        playerAnimator.SetTrigger("TriExit");
    }
    public virtual void Die()
    {
        GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect,0.3f);
        Destroy(gameObject);
        Destroy(FindObjectOfType<WeaponMovement>().gameObject);
    }
    public virtual void OnCollisionEnter2D(Collision2D collisionInfo ){
        if(collisionInfo.collider.tag == "Enemy"){
            Die();
            FindObjectOfType<GameManager>().LevelFailed();
        }
    }   
}
