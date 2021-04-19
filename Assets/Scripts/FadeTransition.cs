using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FadeTransition : MonoBehaviour
{
    public static FadeTransition instance;
    private Image image;

    private float sceneTo;
    private float sceneHold;

    private void Awake()
    {
        //Singleton pattern to ensure we have only one instance of this running at the same time.
        if (instance == null) instance = this;
        else Destroy(transform.parent.gameObject);

        image = GetComponent<Image>();

        DontDestroyOnLoad(transform.parent.gameObject);
    }

    void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public IEnumerator TriggerFade(float fadeTo, float fadeHold)
    {
        image.enabled = true;

        StartCoroutine(DisableControlForSeconds(fadeTo + fadeHold));

        StartCoroutine(Fade(fadeTo, Color.clear, Color.black));

        yield return new WaitForSeconds(fadeTo + fadeHold);

        StartCoroutine(Fade(fadeTo, Color.black, Color.clear));

        yield return new WaitForSeconds(fadeTo);

        image.enabled = false;
    }

    private IEnumerator Fade(float fadeTo, Color fromColor, Color toColor, float fadeHold = 0)
    {
        yield return new WaitForSeconds(fadeHold);
        float elapsedTime = 0;
        while (elapsedTime < fadeTo)
        {
            elapsedTime += Time.deltaTime;
            image.color = Color.Lerp(fromColor, toColor, (elapsedTime / fadeTo));
            yield return null;
        }
    }

    private IEnumerator DisableControlForSeconds(float time)
    {
        PlayerMovement.instance.OnDisable();

        yield return new WaitForSeconds(time);

        PlayerMovement.instance.OnEnable();
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        StartCoroutine(DisableControlForSeconds(sceneHold));
        if (image.color == Color.black) StartCoroutine(Fade(sceneTo, Color.black, Color.clear, sceneHold));
    }

    public void SetSceneParameters(float to, float hold)
    {
        sceneTo = to;
        sceneHold = hold;
        StartCoroutine(TriggerFade(sceneTo, sceneHold));
    }
}