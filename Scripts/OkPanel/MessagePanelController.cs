using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessagePanelController : MonoBehaviour
{
    [SerializeField] private GameObject textPanel;
    private CanvasGroup canvas;

    private void Start()
    {
        CloseMessage();
    }

    public void SetMessage(string msg)
    {
        textPanel.GetComponent<Text>().text = msg;
    }

    public void ShowMessage()
    {
        CanvasManager.ShowCanvas(GetComponent<CanvasGroup>());
    }

    public void CloseMessage()
    {
        CanvasManager.HideCanvas(GetComponent<CanvasGroup>());
    }

    public virtual void OkActionHandler()
    {
        CloseMessage();
    }
}
