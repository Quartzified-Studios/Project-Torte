using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteraction : Interactable
{
    public Vector2 toPosition;
    public float fadeTo;
    public float fadeHold;

    public override void Interact()
    {
        Invoke("Teleport", fadeTo);
        StartCoroutine(FadeTransition.instance.TriggerFade(fadeTo, fadeHold));
    }

    private void Teleport()
    {
        PlayerMovement.instance.transform.position = toPosition;
        PlayerCamera.instance.playerCam.transform.position = (Vector3)toPosition + PlayerCamera.instance.offset;
        PlayerInteraction.instance.interactable = null;
    }
}
