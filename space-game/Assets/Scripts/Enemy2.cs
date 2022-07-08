using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Enemy2 : Enemy
{
    Vector2 movement;

    void Start(){ 
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        movement.x = -1.5f;
        movement.y = 0;
        rb.velocity = movement;
    }
    void FixedUpdate(){
        if(FindObjectOfType<GameManager>().enemy3 != null){
            Rigidbody2D rb3 = FindObjectOfType<GameManager>().enemy3.GetComponent(typeof (Rigidbody2D)) as Rigidbody2D;
            Transform tr3 = FindObjectOfType<GameManager>().enemy3.GetComponent(typeof (Transform)) as Transform;
            if (tr3.position.x <= -1.53f || tr3.position.x >= 1.53f){
                rb3.velocity *= -1f;
            }
        }
        if(FindObjectOfType<GameManager>().enemy1 != null && FindObjectOfType<GameManager>().enemy2 != null){
            Rigidbody2D rb1 = FindObjectOfType<GameManager>().enemy1.GetComponent(typeof (Rigidbody2D)) as Rigidbody2D;
            Rigidbody2D rb2 = FindObjectOfType<GameManager>().enemy2.GetComponent(typeof (Rigidbody2D)) as Rigidbody2D;
            Transform tr1 = FindObjectOfType<GameManager>().enemy1.GetComponent(typeof (Transform)) as Transform;
            Transform tr2 = FindObjectOfType<GameManager>().enemy2.GetComponent(typeof (Transform)) as Transform;
            if (tr1.position.x <= -1.53f || tr2.position.x >= 1.53f){
                rb1.velocity = -movement;
                rb2.velocity = -movement;
                movement = -movement;
            }
       }
       else{
            if(transform.position.x <= -1.36f || transform.position.x >= 1.36f){
                Rigidbody2D rb = GetComponent<Rigidbody2D>();
                rb.velocity *= -1f;
            }
       }
    }
    public override void Die()
    {
        base.Die();
    }
    public override void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        base.OnCollisionEnter2D(collisionInfo);
    }
}
