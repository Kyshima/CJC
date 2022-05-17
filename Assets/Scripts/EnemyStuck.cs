using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStuck : Fighter
{
    private BoxCollider2D hitbox;
    public Animator animator;

    protected void Start()
    {
        hitbox = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
    }

    protected override void ReceiveDamage(Damage dmg)
    {
        animator.SetTrigger("on");
    }
    
    protected override void Death()
    {
        
    }
}
