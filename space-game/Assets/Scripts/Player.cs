using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : ShipParrent
{
    private Animator playerAnimator;
    void Start(){
        playerAnimator = GetComponent<Animator>();
        playerAnimator.SetTrigger("TriEnter");
    }
    public void Exit(){
        playerAnimator.SetTrigger("TriExit");
    }
    public override void Die()
    {
        base.Die();
        Destroy(FindObjectOfType<WeaponMovement>().gameObject);
    }
    public override void OnCollisionEnter2D(Collision2D collisionInfo ){
        if(collisionInfo.collider.tag == "Enemy"){
            Die();
            FindObjectOfType<GameManager>().LevelFailed();
        }
        if(collisionInfo.collider.tag == "Bullet"){
            Die();
            Destroy(collisionInfo.collider.gameObject);
            FindObjectOfType<GameManager>().LevelFailed();
        }
    }   
}
