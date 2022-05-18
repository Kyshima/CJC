using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Mover
{
    public float triggerLenght=0.5f;
    public float chaselenght=1.5f;
    public float speed;

    public int starterHp;

    private bool chasing;
    private bool collidingWithPlayer;
    private Transform playerTransform;
    private Vector3 startingPosition;

    private BoxCollider2D hitbox;
    public ContactFilter2D filter;
    private Collider2D[] hits=new Collider2D[10];

    protected Animator animator;

    protected override void Start()
    {
        base.Start();
        this.xSpeed = speed;
        this.ySpeed = speed;
        playerTransform = GameObject.Find("Player").transform;
        startingPosition = transform.position;
        hitbox = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();

        hp = (int)((GameManager.instance.getLevel() + starterHp) * 1.3);
    }

    private void FixedUpdate()
    {
        if (playerTransform != null)
        {
            if (Vector3.Distance(playerTransform.position, startingPosition) < chaselenght)
            {
                if (Vector3.Distance(playerTransform.position, startingPosition) < triggerLenght)
                    chasing = true;

                if (chasing)
                {
                    animator.SetBool("run", true);
                    if (!collidingWithPlayer)
                    {
                        UpdateMotor((playerTransform.position - transform.position).normalized);
                    }
                }
                else
                {
                    UpdateMotor(startingPosition - transform.position);
                }
            }
            else
            {
                UpdateMotor(startingPosition - transform.position);
                chasing = false;
                animator.SetBool("run", false);
            }
        }

        collidingWithPlayer = false;
        boxCollider.OverlapCollider(filter, hits);
        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i] == null)
                continue;

            if (hits[i].tag == "Fighter" && hits[i].name == "Player") collidingWithPlayer = true;

            hits[i] = null;
        }   
    }
    protected override void Death()
    {
        int xp = Random.Range(10, 15);
        Destroy(gameObject);
        GameManager.instance.xp += xp;
        GameManager.instance.ShowText("+" + xp + " xp", 20, Color.green, transform.position, Vector3.up * 40, 1.0f);
    }
}
