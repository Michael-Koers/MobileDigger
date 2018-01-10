using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MultiActionButtonController : MultiActionDelegate
{
    public ActionButtonDelegate myAction;
    public Text myActionName;

    public void setActionReference(MultiActionDelegate.ActionButtonDelegate action)
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
}
