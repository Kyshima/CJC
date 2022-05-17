    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    private Animator anim;
    private CharMenu charMenu;
    private bool showing = false;
    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        charMenu = gameObject.GetComponent<CharMenu>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.I) || Input.GetKeyDown(KeyCode.B))
        {
            if (!showing)
            {
                anim.SetTrigger("show");
                charMenu.UpdateMenu();
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
