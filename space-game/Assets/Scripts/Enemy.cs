using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : ShipParrent
{
    private Rigidbody2D rb;
    public override void Die(){
    base.Die();
    }
    protected override void OnCollisionEnter2D(Collision2D collisionInfo ){
        base.OnCollisionEnter2D(collisionInfo);
    }
    public Rigidbody2D RB
    {
        get{return rb; }
        set{rb = value; }
    }
}
