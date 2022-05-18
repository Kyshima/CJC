using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Mover
{
    private SpriteRenderer SpriteRenderer;
    private Animator animator;
    private bool isAlive = true;
    private int MaxhpStart = 15;
    private int oLVL;

    protected override void Start()
    {
        base.Start();
        oLVL = GameManager.instance.getLevel();
        SpriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    protected override void ReceiveDamage(Damage dmg)
    {
        if (!isAlive) return;
        if (Time.time - lastImmune > immunity)
        {
            lastImmune = Time.time;
            hp -= dmg.damageAmount;
            PushDirection = (transform.position - dmg.origin).normalized * dmg.pushForce;

            // Mostrar Dano no Ecra

            GameManager.instance.ShowText(dmg.damageAmount.ToString(), new System.Random().Next(18, 35), Color.red, transform.position, Vector3.zero, 0.5f);

            if (hp <= 0)
            {
                hp = 0;
                Death();
            }
        }
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

        if(oLVL != GameManager.instance.getLevel()) {
            hpMax++;
            oLVL = GameManager.instance.getLevel();
        }
    }

    public void Respawn()
    {
        GameManager.instance.xp = 0;
        GameManager.instance.money = 0;
        GameManager.instance.weapon.weaponLevel = 0;
        GameManager.instance.player.hp = MaxhpStart;
        GameManager.instance.player.hpMax = MaxhpStart;
        GameManager.instance.SaveState();
        isAlive = true;
    }

    
}