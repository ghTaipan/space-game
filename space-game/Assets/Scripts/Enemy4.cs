using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy4 : Enemy2
{
    void Start(){
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        movement.y = -1.5f;
        movement.x = -1.5f;

        movement2 = movement;
        movement3 = movement;
        rb.velocity = movement;
    }
    public override void FixedUpdate(){
        base.FixedUpdate();
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
