using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YesNoPanelActionController : MonoBehaviour
{

    public void NoActionHandler()
    {
        LevelController.selected.Cancel();
    }

    public void YesActionHandler()
    {
        LevelController.selected.Confirm();
    }
}
