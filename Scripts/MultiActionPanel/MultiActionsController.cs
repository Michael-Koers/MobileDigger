using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MultiActionsController : MultiActionDelegate
{
    public GameObject actionButton;
    public GameObject actionContainer;
    public Text messageText;
    public GameObject cancelButton;

    public void Awake()
    {
        CanvasManager.HideCanvas(GetComponent<CanvasGroup>());
    }

    public void setMessage(string msg)
    {
        messageText.text = msg;
    }

    public void createActionButtons(Dictionary<string, ActionButtonDelegate> actions)
    {
        foreach (KeyValuePair<string, ActionButtonDelegate> entry in actions)
        {
            GameObject actionButton = Instantiate(this.actionButton, actionContainer.transform);
            actionButton.GetComponent<MultiActionButtonController>().setActionReference(entry.Value);
            actionButton.GetComponent<MultiActionButtonController>().setActionName(entry.Key);
            actionButton.transform.SetParent(actionContainer.transform);
        }
        cancelButton.transform.SetAsLastSibling();
    }

}
