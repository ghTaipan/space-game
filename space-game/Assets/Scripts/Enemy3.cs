using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3 : Enemy
{
    Vector2 movement;
    void Start(){
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        movement.y = -1.5f;
        rb.velocity = movement;
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
