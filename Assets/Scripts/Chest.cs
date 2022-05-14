using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Chest : Collectable
{
    public Sprite empty;
    public int money = 10;

    protected override void OnCollide(Collider2D col)
    {
        //base.OnCollide(col);
        if(!collected && col.name == "Player")
        {
            int money = new System.Random().Next(1,10);
            collected = true;
            GetComponent<SpriteRenderer>().sprite = empty;
            Debug.Log(money);
        }
    }
}