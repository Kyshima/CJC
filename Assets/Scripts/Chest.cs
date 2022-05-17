using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Chest : Collectable
{
    public Sprite empty;

    protected override void OnCollide(Collider2D col)
    {
        if(Input.GetKeyDown(KeyCode.F) && !collected && col.name == "PlayerCollider")
        {
            int rand = new System.Random().Next(0, 100);
            collected = true;
            GetComponent<SpriteRenderer>().sprite = empty;
            if (rand <= 5)
            {
                if (GameManager.instance.weapon.weaponLevel == 0)
                {
                    GameManager.instance.ShowText("Oopsie, Downgrade has failed :c", 25, Color.green, transform.position, Vector3.up * 50, 3.0f);
                }
                else
                {
                    GameManager.instance.Downgrade();
                    GameManager.instance.ShowText("Downgraded!", 25, Color.cyan, transform.position, Vector3.up * 50, 3.0f);
                }
            }
            else if(rand <= 40)
            {
                if (GameManager.instance.weapon.weaponLevel == 6)
                {
                    GameManager.instance.ShowText("Congrats, you're already on the top!", 25, Color.red, transform.position, Vector3.up * 50, 3.0f);
                }
                else { 
                    GameManager.instance.Upgrade(); 
                    GameManager.instance.ShowText("Upgraded :D", 25, Color.cyan, transform.position, Vector3.up * 50, 3.0f); 
                }
            }
            else
            {
                int money = new System.Random().Next(1, 10);
                GameManager.instance.ShowText("+" + money + " coins", 25, Color.yellow, transform.position, Vector3.up * 50, 3.0f);
                GameManager.instance.money += money;
            }



            
        }
    }
}