using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] prefabs;
    public int numPrefabs;
    public int numSpawns;

    protected int rand;
    protected Vector3 coords;
    protected SpriteRenderer s;
    
    void Start()
    {
        s = GetComponent<SpriteRenderer>();

        int rand = Random.Range(0, numPrefabs);
        Vector3[] v = GetSpriteCorners(s);

        for(int i=0; i<numSpawns; i++){
            float x = Random.Range(v[0].x, v[3].x);
            float y = Random.Range(v[2].y, v[3].y);
            coords = new Vector3(x,y,0);

            Instantiate(prefabs[rand],coords,Quaternion.identity);
        }  
    }

    public static Vector3[] GetSpriteCorners(SpriteRenderer renderer)
    {
        Vector3 topRight = renderer.transform.TransformPoint(renderer.sprite.bounds.max);
        Vector3 topLeft = renderer.transform.TransformPoint(new Vector3(renderer.sprite.bounds.max.x, renderer.sprite.bounds.min.y, 0));
        Vector3 botLeft = renderer.transform.TransformPoint(renderer.sprite.bounds.min);
        Vector3 botRight = renderer.transform.TransformPoint(new Vector3(renderer.sprite.bounds.min.x, renderer.sprite.bounds.max.y, 0));
        return new Vector3[] { topRight, topLeft, botLeft, botRight };
    }
}
