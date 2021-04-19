using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneInteraction : Interactable
{
    public string sceneName;
    public float fadeTo;
    public float fadeHold;

    public override void Interact()
    {
        FadeTransition.instance.SetSceneParameters(fadeTo, fadeHold);
        Invoke("TriggerSceneChange", fadeTo);
    }

    private void TriggerSceneChange()
    {
        SceneManager.LoadScene(sceneName);
    }
}
