using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Collidable
{
    public int[] dmg = { 1, 2, 3, 4, 5, 6, 7 };
    public float[] pushForce = { 2.0f, 2.0f, 2.0f, 2.0f, 4.0f, 4.0f, 4.0f };

    public int weaponLevel = 0;
    private SpriteRenderer sprite;
    private Sprite newSprite;

    private Animator animator;
    private float cooldown = 0.5f;
    private float lastSwing;

    protected override void Start()
    {
        GameManager.instance.weapon = this;
        base.Start();
        //sprite = GameManager.instance.weaponSprite[weaponLevel];
        sprite = GetComponent<SpriteRenderer>();
        newSprite = GameManager.instance.weaponSprite[weaponLevel];
        sprite.sprite = newSprite;
        animator = GetComponent<Animator>();
    }

    protected override void Update()
    {
        base.Update();

        if(Input.GetMouseButtonDown(0)){
            if(Time.time - lastSwing > cooldown){
                lastSwing = Time.time;
                Swing();
            }
        }
    }

    protected override void OnCollide(Collider2D col)
    {
        if(col.tag == "Fighter" && col.name != "Player"){
            //Debug.Log(col.name);
            Damage d = new Damage { origin = transform.position, damageAmount = dmg[weaponLevel], pushForce = pushForce[weaponLevel]};
            col.SendMessage("ReceiveDamage", d);
        }
    }

    private void Swing(){
        if(GameManager.instance.fight) animator.SetTrigger("Swing");
    }

    public void UpgradeWeapon()
    {
        weaponLevel++;
        sprite.sprite = GameManager.instance.weaponSprite[weaponLevel];
    }

    public void DowngradeWeapon()
    {
        weaponLevel--;
        sprite.sprite = GameManager.instance.weaponSprite[weaponLevel];
    }

    public void UpdateSprite()
    {
        sprite.sprite = GameManager.instance.weaponSprite[weaponLevel];
    }
}