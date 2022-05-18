using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    private Queue<string> sentences;
    public Text dialogueText;
    public bool final = false;

    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            DisplayNextSentence();
        }
    }

    public void StartDialogue(Dialogue dialogue)
    {
        //Debug.Log("Start Convo");
        animator.SetBool("isOpen", true);
        sentences.Clear();

        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            if (final)
            {
                EndDialogue();
                final = false;
                return;
            }

            dialogueText.text = System.Environment.UserName;
            final = true;
        }
        else
        {
            string sentence = sentences.Dequeue();
            dialogueText.text = sentence;
        }
    }

    void EndDialogue()
    {
        
        animator.SetBool("isOpen", false);
        //Debug.Log("Acabou Dialogo");
    }
}
