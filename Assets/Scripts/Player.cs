using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
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
        base.ReceiveDamage(dmg);
    }

    protected override void Death()
    {
        isAlive = false;
        GameManager.instance.fight=false;
        GameManager.instance.deathAnim.SetTrigger("Dead");
        //Destroy(gameObject);
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