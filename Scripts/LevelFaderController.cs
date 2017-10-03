using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelFaderController : MonoBehaviour
{
    private CanvasGroup canvas;
    private Text levelText;

    public float fadeInDuration;
    public float levelDisplayDuration;
    public float fadeAwayDuration;

    private LevelManager levelManager;

    private void Awake()
    {
        levelManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<LevelManager>();
        canvas = GetComponent<CanvasGroup>();
        levelText = GetComponentInChildren<Text>();
        levelText.text = levelManager.GetLevelToString();
        StartCoroutine(InitialLevelDisplay());
    }

    public IEnumerator InitialLevelDisplay()
    {
        yield return PauseLevel();
        yield return HideLevel();
    }

    public IEnumerator DisplayLevel()
    {
        levelText.text = levelManager.GetLevelToString();
        yield return StartCoroutine(ShowLevel());
        yield return StartCoroutine(PauseLevel());
        yield return StartCoroutine(HideLevel());
    }

    public IEnumerator PauseLevel()
    {
        yield return new WaitForSeconds(levelDisplayDuration);
    }

    public IEnumerator ShowLevel()
    {
        canvas.blocksRaycasts = true;
        yield return StartCoroutine(FadeImage(false));
    }

    public IEnumerator HideLevel()
    {
        yield return StartCoroutine(FadeImage(true));
        canvas.alpha = 0f;
        canvas.blocksRaycasts = false;
    }

    private IEnumerator FadeImage(bool fadeAway)
    {
        // fade from opaque to transparent
        if (fadeAway)
        {
            // loop over x second backwards
            for (float i = fadeAwayDuration; i >= 0; i -= Time.deltaTime)
            {
                // set color with i as alpha
                canvas.alpha = (i / fadeAwayDuration);
                yield return null;
            }
        }
        // fade from transparent to opaque
        else
        {
            // loop over x second
            for (float i = 0; i <= fadeInDuration; i += Time.deltaTime)
            {
                // set color with i as alpha
                canvas.alpha = (i / fadeInDuration);
                yield return null;
            }
        }
    }
}
