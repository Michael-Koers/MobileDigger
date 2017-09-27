using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitController : MonoBehaviour
{

    private CanvasGroup nextLevelCanvas;

    void Start()
    {
        nextLevelCanvas = GameObject.FindGameObjectWithTag("NextLevelCanvas").GetComponent<CanvasGroup>();
    }

    public void onMouseClick()
    {
        ShowNextLevelPanel();
    }

    private void ShowNextLevelPanel()
    {
        nextLevelCanvas.alpha = 1f;
        nextLevelCanvas.blocksRaycasts = true;
    }

    public void HideNextLevelPanel()
    {
        nextLevelCanvas.alpha = 0f;
        nextLevelCanvas.blocksRaycasts = false;
    }
}
