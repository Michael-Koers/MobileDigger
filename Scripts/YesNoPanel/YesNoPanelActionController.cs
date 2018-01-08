using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YesNoPanelActionController : MonoBehaviour
{
    public virtual void NoActionHandler()
    {
        LevelController.selected.Cancel();
    }

    public virtual void YesActionHandler()
    {
        LevelController.selected.Confirm();
    }
}
