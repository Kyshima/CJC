using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : MonoBehaviour
{
    public int hp=10;
    public int maxHitPoint=10;
    public float pushRecovery = 0.2f;

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
            Debug.Log(dmg.damageAmount + " -> " + hp);

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
