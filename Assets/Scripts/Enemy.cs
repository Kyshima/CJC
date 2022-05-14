using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Mover
{
    public int xp=1;

    public float triggerLenght=0.5f;
    public float chaselenght=1.5f;
    private bool chasing;
    private bool collidingWithPlayer;
    private Transform playerTransform;
    private Vector3 startingPosition;

    private BoxCollider2D hitbox;
    public ContactFilter2D filter;
    private Collider2D[] hits=new Collider2D[10];

    protected override void Start()
    {
        base.Start();
        this.xSpeed = 0.3f;
        this.ySpeed = 0.3f;
        this.hp=hp/3;
        playerTransform = GameObject.Find("Player").transform;
        startingPosition = transform.position;
        hitbox = GetComponent<BoxCollider2D>();
    }

    private void FixedUpdate()
    {
        if (Vector3.Distance(playerTransform.position, startingPosition) < chaselenght)
        {
            if(Vector3.Distance(playerTransform.position, startingPosition) < triggerLenght)
                chasing = true;

            if (chasing)
            {
                if (!collidingWithPlayer)
                {
                    UpdateMotor((playerTransform.position - transform.position).normalized);
                }
            } else {
                UpdateMotor(startingPosition - transform.position);
            }
        } else {
            UpdateMotor(startingPosition - transform.position);
            chasing = false;
        }

        collidingWithPlayer = false;
        boxCollider.OverlapCollider(filter, hits);
        for (int i=0; i<hits.Length; i++)
        {
            if (hits[i] == null)
                continue;

            if(hits[i].tag == "Fighter" && hits[i].name == "Player") collidingWithPlayer = true; 

            hits[i]=null;
        } 
    }
}
