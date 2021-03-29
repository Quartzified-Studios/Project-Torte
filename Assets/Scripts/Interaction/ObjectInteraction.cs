using UnityEngine;

public class ObjectInteraction : Interactable
{
    bool rotate = false;

    public override void Interact()
    {
        rotate = !rotate;
    }

    private void Update()
    {
        if (rotate) DoABarrerRoll();
    }

    private void DoABarrerRoll()
    {
        //This function is just to test the object interaction
        transform.Rotate(Vector3.forward * -90 * Time.deltaTime);
    }
}
