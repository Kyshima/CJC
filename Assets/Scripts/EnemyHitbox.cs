using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitbox : Collidable
{
    public int dmg;
    public float pushForce;

    protected override void OnCollide(Collider2D col){
        if(col.tag == "Fighter" && col.name == "Player"){
            Damage d = new Damage{origin=transform.position, damageAmount=dmg, pushForce=pushForce};
            col.SendMessage("ReceiveDamage", d);
        }
    }

    
}
