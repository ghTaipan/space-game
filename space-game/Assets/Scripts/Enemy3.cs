using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3 : Enemy
{
    private Vector2 movement;
    public void Start(){
        RB = GetComponent<Rigidbody2D>();
        movement.y = -1.5f;
        RB.velocity = movement;
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
