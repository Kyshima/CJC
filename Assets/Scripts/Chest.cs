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
            int money = new System.Random().Next(1,10);
            collected = true;
            GetComponent<SpriteRenderer>().sprite = empty;
            GameManager.instance.ShowText("+" + money + " coins", 25, Color.yellow, transform.position, Vector3.up * 50, 3.0f);
        }
    }
}