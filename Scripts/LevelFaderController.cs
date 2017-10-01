using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelFaderController : MonoBehaviour
{

    private CanvasGroup canvas;
    private Text levelText;
    public float fadeDuration;

    private void Awake()
    {
        Debug.Log("Doing something?");
        canvas = GetComponent<CanvasGroup>();
        levelText = GetComponentInChildren<Text>();
        StartCoroutine(HideLevel());
    }

    public IEnumerator DisplayLevel()
    {
        yield return StartCoroutine(ShowLevel());
        yield return StartCoroutine(HideLevel());       
    }

    public IEnumerator ShowLevel()
    {
        canvas.blocksRaycasts = true;
        yield return StartCoroutine(FadeImage(false));
    }

    public IEnumerator HideLevel()
    {
        yield return StartCoroutine(FadeImage(true));
        canvas.blocksRaycasts = false;
    }

    IEnumerator FadeImage(bool fadeAway)
    {
        levelText.text = "Level " + LevelManager.level;

        // fade from opaque to transparent
        if (fadeAway)
        {
            // loop over 1 second backwards
            for (float i = fadeDuration; i >= 0; i -= Time.deltaTime)
            {
                // set color with i as alpha
                canvas.alpha = i;
                yield return null;
            }
        }
        // fade from transparent to opaque
        else
        {
            // loop over 1 second
            for (float i = 0; i <= fadeDuration; i += Time.deltaTime)
            {
                // set color with i as alpha
                canvas.alpha = i;
                yield return null;
            }
        }
    }
}
