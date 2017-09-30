using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessagePanelController : MonoBehaviour
{

    private void Start()
    {
        GetComponentInParent<CanvasGroup>().blocksRaycasts = false;
        GetComponentInParent<CanvasGroup>().alpha = 0f;

    }
}
