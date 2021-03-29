using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public GameObject interactSign;

    public void changeStateSign()
    {
        interactSign.SetActive(!interactSign.activeSelf);
    }

    public abstract void Interact();
}
