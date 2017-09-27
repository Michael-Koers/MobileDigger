using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinuePanelController : MonoBehaviour
{

    private void Start()
    {
        CanvasGroup canvas = GameObject.FindGameObjectWithTag("NextLevelCanvas").GetComponent<CanvasGroup>();
        canvas.alpha = 0f;
        canvas.blocksRaycasts = false;
    }
}
