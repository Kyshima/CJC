using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Collidable
{
    public int dmg = 1;
    public float pushForce = 2.0f;

    public int weaponLevel = 0;
    private SpriteRenderer sprite;

    private float cooldown = 0.5f;
    private float lastSwing;

    protected override void Start()
    {
        base.Start();
        sprite = GetComponent<SpriteRenderer>();
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
            Damage d = new Damage{origin=transform.position, damageAmount=dmg, pushForce=pushForce};
            col.SendMessage("ReceiveDamage", d);
        }
    }

    private void Swing(){
        Debug.Log("Swing");
    }
}