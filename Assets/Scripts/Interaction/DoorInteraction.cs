using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteraction : Interactable
{
    public Vector2 toPosition;

    public override void Interact()
    {
        PlayerMovement.instance.transform.position = toPosition;
        PlayerCamera.instance.playerCam.transform.position = (Vector3)toPosition + PlayerCamera.instance.offset;
        PlayerInteraction.instance.interactable = null;
    }
}
