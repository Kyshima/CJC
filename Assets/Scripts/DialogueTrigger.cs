using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : Collidable
{

    public Dialogue dialogue;

    public void TriggerDialogue()
    {
        if (FindObjectOfType<DialogueManager>().reset)
        {
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
            FindObjectOfType<DialogueManager>().reset = false ;
        }
        else FindObjectOfType<DialogueManager>().DisplayNextSentence();
    }

    protected override void OnCollide(Collider2D col)
    {
        if (Input.GetKeyDown(KeyCode.F) && col.name == "PlayerCollider")
        {
            TriggerDialogue();
        }
    }

}
