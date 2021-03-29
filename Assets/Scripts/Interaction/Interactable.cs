using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public GameObject interactSign;

    public void changeStateSign()
    {
        if(interactSign != null)
        {
            interactSign.SetActive(!interactSign.activeSelf);
        }

    }

    public abstract void Interact();
}
