using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : Enemy
{
    Vector2 movement;
    void FixedUpdate(){
        movement.x = -0.02f;
        movement.y = 0;
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
         rb.AddForce(movement, ForceMode2D.Impulse);
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
