using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : Collidable
{
    public Dialogue dialogue;

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    protected override void OnCollide(Collider2D col)
    {
        if (Input.GetKeyDown(KeyCode.F) && col.name == "PlayerCollider")
        {
            TriggerDialogue();
        }
    }

}
