using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitbox : Collidable
{
    public int dmg;
    public float pushForce;

    protected override void OnCollide(Collider2D col){
        if(col.tag == "Fighter" && col.name == "Player"){
            Damage d = new Damage{origin=transform.position, damageAmount=(int)(dmg + GameManager.instance.getLevel()*0.45), pushForce=pushForce};
            col.SendMessage("ReceiveDamage", d);
        }
    }

    
}
    