using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy4 : Enemy2
{
    private void Start(){
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        movement.y = -1.5f;
        movement.x = -1.8f;

        movement2 = movement;
        movement3 = movement;
        rb.velocity = movement;
    }
    protected override void FixedUpdate(){
        base.FixedUpdate();
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
