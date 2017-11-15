using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoButtonController : MonoBehaviour
{

    public void CancelNextLevel()
    {
        LevelController.selected.cancel();
        //ExitController exit = GameObject.FindGameObjectWithTag("Exit").GetComponent<ExitController>();
        //CanvasManager.HideCanvas(exit.nextLevelCanvas);
    }
}
