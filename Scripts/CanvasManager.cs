using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour {

    //Generic method to hide a canvasgroup
	public static void HideCanvas(CanvasGroup canvas)
    {
        canvas.alpha = 0f;
        canvas.blocksRaycasts = false;
    }

    //Generic method to show a canvasgroup
    public static void ShowCanvas(CanvasGroup canvas)
    {
        canvas.alpha = 1f;
        canvas.blocksRaycasts = true;
    }
}
