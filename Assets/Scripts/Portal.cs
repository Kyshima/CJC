using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class Portal : Collidable
{
    public string[] sceneNames;

    protected override void OnCollide(Collider2D col)
    {
        if(col.name == "Player")
        {
            string SceneName = sceneNames[new System.Random().Next(0,sceneNames.Length)];
            SceneManager.LoadScene(SceneName);
        }
    }
}