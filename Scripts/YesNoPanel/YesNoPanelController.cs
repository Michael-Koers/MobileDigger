using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class YesNoPanelController : MonoBehaviour
{
    [SerializeField] private GameObject textPanel;

    private void Start()
    {
        CanvasGroup canvas = GameObject.FindGameObjectWithTag("YesNoCanvas").GetComponent<CanvasGroup>();
        CanvasManager.HideCanvas(canvas);
    }

    public void SetMessage(string message)
    {
        textPanel.GetComponent<Text>().text = message;
    }

}
