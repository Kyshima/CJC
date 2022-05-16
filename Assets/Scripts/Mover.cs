using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Mover : Fighter
{
    protected BoxCollider2D boxCollider;
    protected Vector3 moveDelta;
    protected RaycastHit2D hit;
    protected float ySpeed = 0.75f;
    protected float xSpeed = 1f;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        if(gameObject.name == "Player")
        boxCollider = gameObject.transform.Find("PlayerCollider").GetComponent<BoxCollider2D>();
        else boxCollider = GetComponent<BoxCollider2D>();
    }

    protected virtual void UpdateMotor(Vector3 input)
    {
        // Reset ao moveDelta
        moveDelta = new Vector3(input.x*xSpeed, input.y*ySpeed, 0);

        // Vira o sprite a andar para a direita ou esquerda
        if(moveDelta.x > 0) transform.localScale = Vector3.one;
        else if(moveDelta.x < 0) transform.localScale = new Vector3(-1,1,1);

        // Adiciona Knockback, se houver
        moveDelta += PushDirection;

        // Reduz a forca do knockback por frame, baseado no recovery speed
        PushDirection = Vector3.Lerp(PushDirection, Vector3.zero, pushRecovery);
        
        // Verifica se pode mover em, e move-se
        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(0,moveDelta.y), Mathf.Abs(moveDelta.y * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));
        if(hit.collider == null) transform.Translate(0, moveDelta.y * Time.deltaTime, 0);

        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(moveDelta.x,0), Mathf.Abs(moveDelta.x * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));
        if(hit.collider == null) transform.Translate(moveDelta.x * Time.deltaTime, 0, 0);
    }
}
