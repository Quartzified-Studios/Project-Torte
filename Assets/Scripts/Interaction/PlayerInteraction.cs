using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public static PlayerInteraction instance;

    public Interactable interactable;

    InputMaster controls;

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);

        controls = new InputMaster();
    }

    private void Start()
    {
        controls.Player.Interaction.performed += ctx => InteractWithInteractable();
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

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
            DialogueManager.instance.ClearDisableDialogue();
        }
    }

    void InteractWithInteractable()
    {
        if (interactable != null)
        {
            interactable.Interact();
        }
    }
}
