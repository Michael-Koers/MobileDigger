using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OkButtonController : MonoBehaviour
{

    public void onMouseClick()
    {
        GetComponentInParent<CanvasGroup>().blocksRaycasts = false;
        GetComponentInParent<CanvasGroup>().alpha = 0f;
    }
}
