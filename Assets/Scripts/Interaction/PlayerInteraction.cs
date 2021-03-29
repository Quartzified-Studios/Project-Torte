using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private Interactable interactable;

    //If there's no interactable then set it
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Interactable collidedInteractable = collision.GetComponent<Interactable>();
        if (interactable == null && collidedInteractable != null)
        {
            interactable = collidedInteractable;
            interactable.changeStateSign();
        }
    }

    //If the player left current interactable area then set it to null
    private void OnTriggerExit2D(Collider2D collision)
    {
        Interactable collidedInteractable = collision.GetComponent<Interactable>();
        if (interactable != null && collidedInteractable == interactable)
        {
            interactable.changeStateSign();
            interactable = null;
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && interactable != null)
        {
            interactable.Interact();
        }
    }
}
