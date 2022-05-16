using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Mover
{
    private SpriteRenderer SpriteRenderer;
    private Animator animator;

    protected override void Start()
    {
        base.Start();
        SpriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }
    private void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        if(x!=0 || y!=0) animator.SetTrigger("Run");
        else animator.ResetTrigger("Run");

        UpdateMotor(new Vector3(x,y,0));
    }
}
