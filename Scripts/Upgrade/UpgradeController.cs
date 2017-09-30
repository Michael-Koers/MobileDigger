using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeController : MonoBehaviour {

    private CanvasGroup messageCanvas;
    private Text message;

    private void Awake()
    {
        messageCanvas = GameObject.FindGameObjectWithTag("MessageCanvas").GetComponent<CanvasGroup>();
        message = GameObject.FindGameObjectWithTag("MessageText").GetComponent<Text>();
    }

    public void onMouseClick()
    {
        Debug.Log("Clicked");
        message.text = "You need to be on the surface to purchase upgrades!";
        messageCanvas.alpha = 1f;
        messageCanvas.blocksRaycasts = true;
    }
}
