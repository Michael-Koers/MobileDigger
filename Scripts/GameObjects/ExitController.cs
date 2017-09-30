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

        //If a dirt block is selected, unselect it and hide dig button
        if (DirtController.selected)
        {
            DirtController.selected.HideDigButton();
            DirtController.selected = null;
        }
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
