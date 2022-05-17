using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Mover
{
    private SpriteRenderer SpriteRenderer;
    private Animator animator;
    private bool isAlive = true;

    protected override void Start()
    {
        base.Start();
        this.hp=10;
        SpriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    protected override void ReceiveDamage(Damage dmg)
    {
        if (!isAlive) return;
        base.ReceiveDamage(dmg);
    }

    protected override void Death()
    {
        isAlive = false;
        Destroy(gameObject);
        GameManager.instance.deathAnim.SetTrigger("Dead");
    }

    private void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        if(x!=0 || y!=0) animator.SetTrigger("Run");
        else animator.ResetTrigger("Run");

        if(isAlive) UpdateMotor(new Vector3(x,y,0));
    }

    public void Respawn()
    {
        this.hp = 10;
        isAlive = true;
    }

    
}
