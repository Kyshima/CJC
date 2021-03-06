using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collidable : MonoBehaviour
{
    public ContactFilter2D filter;
    private BoxCollider2D boxCollider;
    private Collider2D[] hits = new Collider2D[10];

    protected virtual void Start()
    {
        boxCollider=GetComponent<BoxCollider2D>();
    }

    protected virtual void Update()
    {
       boxCollider.OverlapCollider(filter, hits);
        for (int i=0; i<hits.Length; i++)
        {
            if (hits[i] == null)
                continue;

            //Debug.Log(i);
            OnCollide(hits[i]);            

            hits[i]=null;
        } 
    }

    protected virtual void OnCollide(Collider2D col) 
    {
        Debug.Log("Isto ainda nao foi imprementado em: " + col.name);
    }
}