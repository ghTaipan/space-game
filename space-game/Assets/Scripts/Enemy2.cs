using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Enemy2 : Enemy
{
    public Vector2 movement;
    public Vector2 movement2;
    public Vector2 movement3;
    void Start(){ 
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        movement.x = -1.5f;
        movement.y = 0;
        movement2 = movement;
        movement3 = movement;
        rb.velocity = movement;
    }
    public virtual void FixedUpdate(){
        if(FindObjectOfType<GameManager>().enemy3 != null){
            Rigidbody2D rb3 = FindObjectOfType<GameManager>().enemy3.GetComponent(typeof (Rigidbody2D)) as Rigidbody2D;
            Transform tr3 = FindObjectOfType<GameManager>().enemy3.GetComponent(typeof (Transform)) as Transform;
            if (tr3.position.x <= -1.53f || tr3.position.x >= 1.53f){
                movement3.x *= -1f;
                rb3.velocity = movement3;
            }
        }
        if(FindObjectOfType<GameManager>().enemy1 != null && FindObjectOfType<GameManager>().enemy2 != null){
            Rigidbody2D rb1 = FindObjectOfType<GameManager>().enemy1.GetComponent(typeof (Rigidbody2D)) as Rigidbody2D;
            Rigidbody2D rb2 = FindObjectOfType<GameManager>().enemy2.GetComponent(typeof (Rigidbody2D)) as Rigidbody2D;
            Transform tr1 = FindObjectOfType<GameManager>().enemy1.GetComponent(typeof (Transform)) as Transform;
            Transform tr2 = FindObjectOfType<GameManager>().enemy2.GetComponent(typeof (Transform)) as Transform;
            if (tr1.position.x <= -1.53f || tr2.position.x >= 1.53f){
                movement.x *= -1f;
                movement2.x *= -1f;
                rb1.velocity = movement;
                rb2.velocity = movement2;
            }
       }
       else{
            if(FindObjectOfType<GameManager>().enemy2 != null && FindObjectOfType<GameManager>().enemy1 == null){
                Rigidbody2D rb2 = FindObjectOfType<GameManager>().enemy2.GetComponent(typeof (Rigidbody2D)) as Rigidbody2D;
                Transform tr2 = FindObjectOfType<GameManager>().enemy2.GetComponent(typeof (Transform)) as Transform;
                if (tr2.position.x <= -1.53f || tr2.position.x >= 1.53f){
                    movement2.x *= -1f;
                    rb2.velocity = movement2;
                }
            }
            if(FindObjectOfType<GameManager>().enemy1 != null && FindObjectOfType<GameManager>().enemy2 == null){
                Rigidbody2D rb1 = FindObjectOfType<GameManager>().enemy1.GetComponent(typeof (Rigidbody2D)) as Rigidbody2D;
                Transform tr1 = FindObjectOfType<GameManager>().enemy1.GetComponent(typeof (Transform)) as Transform;
                if(FindObjectOfType<GameManager>().mod >= 1){
                    if (tr1.position.x <= -1.53f || tr1.position.x >= 1.53f){
                        movement.x *= -1f;
                        rb1.velocity = movement;
                    }
                }
                else{
                    if ((tr1.position.x <= -1.36f || tr1.position.x >= 1.36f)){
                        movement.x *= -1f;
                        rb1.velocity = movement;
                    }
                }
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
