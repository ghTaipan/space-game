using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Enemy2 : Enemy
{
    protected Vector2 movement;
    protected Vector2 movement2;
    protected Vector2 movement3;
    
    private void Start(){ 
        RB = GetComponent<Rigidbody2D>();
        movement.x = -1.5f;
        movement.y = 0;
        movement2 = movement;
        movement3 = movement;
        RB.velocity = movement;
    }
    public virtual void StartAfterPause(Vector2 movement1){
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        movement = movement1;
        movement2 = movement;
        movement3 = movement;
        rb.velocity = movement;
    }
    protected virtual void FixedUpdate(){
        if(!gameObject.GetComponent<Rigidbody2D>() && FindObjectOfType<GameManager>().Lose == false){
            gameObject.AddComponent<Rigidbody2D>();
            gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
            StartAfterPause(movement);
        }
        if(FindObjectOfType<GameManager>() == null ){ //for tutorial
            if(FindObjectOfType<EnemyTutorial>().enemy3 != null){
                    Rigidbody2D rb3 = FindObjectOfType<EnemyTutorial>().enemy3.GetComponent(typeof (Rigidbody2D)) as Rigidbody2D;
                    Transform tr3 = FindObjectOfType<EnemyTutorial>().enemy3.GetComponent(typeof (Transform)) as Transform;
                    if (tr3.position.x <= -2.5f || tr3.position.x >= 2.5f){
                        movement3.x *= -1f;
                        rb3.velocity = movement3;
                    }
                }
            Rigidbody2D rb1 = FindObjectOfType<EnemyTutorial>().enemy1.GetComponent(typeof (Rigidbody2D)) as Rigidbody2D;
            Transform tr1 = FindObjectOfType<EnemyTutorial>().enemy1.GetComponent(typeof (Transform)) as Transform;
            if(FindObjectOfType<EnemyTutorial>().enemy2 != null){
                Rigidbody2D rb2 = FindObjectOfType<EnemyTutorial>().enemy2.GetComponent(typeof (Rigidbody2D)) as Rigidbody2D;
                Transform tr2 = FindObjectOfType<EnemyTutorial>().enemy2.GetComponent(typeof (Transform)) as Transform;
                if (tr1.position.x <= -2.5f || tr1.position.x >= 2.5f || tr2.position.x <= -2.5f || tr2.position.x >= 2.5f ){
                    movement.x *= -1f;
                    rb1.velocity = movement;
                    movement2.x *= -1f;
                     rb2.velocity = movement2;
                }
            }
            else{
                if(tr1.position.x <= -2.5f || tr1.position.x >= 2.5f){
                movement.x *= -1f;
                rb1.velocity = movement;
                }
            }
        }
        else{
            if(FindObjectOfType<GameManager>().enemy3 != null){
                Rigidbody2D rb3 = FindObjectOfType<GameManager>().enemy3.GetComponent(typeof (Rigidbody2D)) as Rigidbody2D;
                Transform tr3 = FindObjectOfType<GameManager>().enemy3.GetComponent(typeof (Transform)) as Transform;
                if (tr3.position.x <= -2.5f || tr3.position.x >= 2.5f){
                    movement3.x *= -1f;
                    rb3.velocity = movement3;
                }
            }
            
            if(FindObjectOfType<GameManager>().enemy1 != null && FindObjectOfType<GameManager>().enemy2 != null){
                Rigidbody2D rb1 = FindObjectOfType<GameManager>().enemy1.GetComponent(typeof (Rigidbody2D)) as Rigidbody2D;
                Rigidbody2D rb2 = FindObjectOfType<GameManager>().enemy2.GetComponent(typeof (Rigidbody2D)) as Rigidbody2D;
                Transform tr1 = FindObjectOfType<GameManager>().enemy1.GetComponent(typeof (Transform)) as Transform;
                Transform tr2 = FindObjectOfType<GameManager>().enemy2.GetComponent(typeof (Transform)) as Transform;
                if (tr1.position.x <= -2.5f || tr2.position.x >= 2.5f){
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
                    if (tr2.position.x <= -2.5f || tr2.position.x >= 2.5f){
                        movement2.x *= -1f;
                        rb2.velocity = movement2;
                    }
                }
                if(FindObjectOfType<GameManager>().enemy1 != null && FindObjectOfType<GameManager>().enemy2 == null){
                    Rigidbody2D rb1 = FindObjectOfType<GameManager>().enemy1.GetComponent(typeof (Rigidbody2D)) as Rigidbody2D;
                    Transform tr1 = FindObjectOfType<GameManager>().enemy1.GetComponent(typeof (Transform)) as Transform;
                    if(FindObjectOfType<GameManager>().Mod >= 1){
                        if (tr1.position.x <= -2.5f || tr1.position.x >= 2.5f){
                            movement.x *= -1f;
                            rb1.velocity = movement;
                        }
                    }
                    else{
                        if ((tr1.position.x <= -2.35f || tr1.position.x >= 2.35f)){
                            movement.x *= -1f;
                            rb1.velocity = movement;
                        }
                    }
                }
            }
        }
    }
    public override void Die()
    {
        base.Die();
    }
    protected override void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        base.OnCollisionEnter2D(collisionInfo);
    }
    
}
