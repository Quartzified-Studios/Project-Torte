using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance;
    public TextMeshProUGUI nameText, dialogueText;
    public GameObject canvas;
    private string currentActorName;
    Queue<string> text;
    Queue<Actor> actor;

    private void Awake()
    {
        //Singleton pattern to ensure we have only one instance of this running at the same time.
        if(instance == null) instance = this;
        else Destroy(gameObject);

        //Initialize Queues
        text = new Queue<string>();
        actor = new Queue<Actor>();
    }

    //Setting up dialogQueue
    public void StartDialogue(Dialogue dialogue)
    {
        canvas.SetActive(true);

        //Clearing queues to make sure there's nothing in there
        text.Clear();
        actor.Clear();

        //Filling queues with data
        for (int i = 0; i < dialogue.text.Length; i++)
        {
            text.Enqueue(dialogue.text[i]);
            actor.Enqueue(dialogue.actor[i]);
        }

        Next();
    }

    //Playing dialog
    public void Next()
    {
        if(text.Count == 0)
        {
            //End of dialogue
            canvas.SetActive(false);
        }
        else
        {
            //Setting UI Text actor and taking out first item from actor queue
            Actor a = actor.Dequeue();
            if (a == null)
            {
                //If there's no actor on the dialog we grab the last one, if there's no last one we show a "Name missing" message
                nameText.text = currentActorName == null ? "Name Missing" : currentActorName;
            }
            else
            {
                //Setting actor's name and UI Text
                currentActorName = a.name;
                nameText.text = a.name;
            }

            //Setting UI Text dialog and taking out first item from dialog queue
            dialogueText.text = text.Dequeue();
        }
    }
}
