using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Fighter : MonoBehaviour
{
    public int hpMax;
    public int hp;
    public float pushRecovery;

    protected float immunity = 1.0f;
    protected float lastImmune;

    protected Vector3 PushDirection;

    protected virtual void ReceiveDamage(Damage dmg)
    {
        if(Time.time - lastImmune > immunity){
            lastImmune = Time.time;
            hp-=dmg.damageAmount;
            PushDirection = (transform.position - dmg.origin).normalized * dmg.pushForce;

            // Mostrar Dano no Ecra

            GameManager.instance.ShowText(dmg.damageAmount.ToString(), new System.Random().Next(18,35), Color.magenta, transform.position, Vector3.zero, 0.5f);

            if(hp<=0){
                hp=0;
                Death();    
            }
        }
    }

    protected virtual void Death()
    {
        Destroy(gameObject);
    }
}
