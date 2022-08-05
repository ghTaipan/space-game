using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : ShipParrent
{
        public override void Die(){
        base.Die();
    }
    public override void OnCollisionEnter2D(Collision2D collisionInfo ){
        base.OnCollisionEnter2D(collisionInfo);
    }
}
