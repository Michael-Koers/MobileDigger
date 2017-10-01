using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitController : MonoBehaviour
{

    [HideInInspector] public CanvasGroup nextLevelCanvas;

    private void Start()
    {
        nextLevelCanvas = GameObject.FindGameObjectWithTag("NextLevelCanvas").GetComponent<CanvasGroup>();
    }

    public void onMouseClick()
    {
        CanvasManager.ShowCanvas(nextLevelCanvas);

        //If a dirt block is selected, unselect it and hide dig button
        if (DirtController.selected)
        {
            CanvasManager.HideCanvas(DirtController.selected.hpCanvas);
            DirtController.selected = null;
        }
    }
}
