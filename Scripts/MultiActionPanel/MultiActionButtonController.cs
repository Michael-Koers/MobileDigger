﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MultiActionButtonController : MultiActionDelegate
{
    public ActionButtonDelegate myAction;
    public Text myActionName;

    public void setActionReference(ActionButtonDelegate action)
    {
        myAction = action;
    }

    public void setActionName(string actionName)
    {
        myActionName.text = actionName;
    }

    public void onMouseClick()
    {
        myAction();
    }

    public void Cancel()
    {
        CanvasManager.HideCanvas(GameObject.FindGameObjectWithTag("MultiActionCanvas").GetComponent<CanvasGroup>());
    }
}
