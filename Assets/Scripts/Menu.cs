    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    private Animator anim;
    private bool showing = false;
    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.I) || Input.GetKeyDown(KeyCode.B))
        {
            if (!showing)
            {
                anim.SetTrigger("show");
                showing = true;
            }
            else
            {
                anim.SetTrigger("hide");
                showing = false;
            }
        }
    }
}
