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
        if(Input.GetKeyDown(KeyCode.F) && col.name == "PlayerCollider")
        {
            if(GameManager.instance.player.hp + GameManager.instance.player.hpMax/2 <= GameManager.instance.player.hpMax)
                GameManager.instance.player.hp += GameManager.instance.player.hpMax/2;
            else GameManager.instance.player.hp = GameManager.instance.player.hpMax;
            GameManager.instance.SaveState();
            string SceneName = sceneNames[new System.Random().Next(0,sceneNames.Length)];
            SceneManager.LoadScene(SceneName);
        }
    }
}
