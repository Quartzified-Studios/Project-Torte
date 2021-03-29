using UnityEngine;

public class NPCInteraction : Interactable
{
    [SerializeField] Dialogue dialogue;

    public override void Interact()
    {
        TriggerDialogue();
    }

    private void TriggerDialogue()
    {
        //Checking if canvas is active, if it is then play next dialog, if not then start it
        if(dialogue != null)
        {
            if(DialogueManager.instance.canvas.activeInHierarchy == true)
            {
                DialogueManager.instance.Next();
            }
            else
            {
                DialogueManager.instance.StartDialogue(dialogue);
            }
        }
    }
}
