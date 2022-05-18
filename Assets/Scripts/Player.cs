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
        GameManager.instance.deathAnim.SetTrigger("Dead");
        Destroy(gameObject);
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
        GameManager.instance.xp = 0;
        GameManager.instance.money = 0;
        GameManager.instance.weapon.weaponLevel = 0;
        GameManager.instance.player.hp = 10;
        GameManager.instance.SaveState();
        isAlive = true;
    }

    
}