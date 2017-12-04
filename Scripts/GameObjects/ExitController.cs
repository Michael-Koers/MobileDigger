using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitController : LevelController
{
    public void onMouseClick()
    {
        selected = this;
        yesNoController.SetMessage(nextLevelMessage);
        CanvasManager.ShowCanvas(yesNoCanvas);
        UnselectDirt();
    }

    public override void Confirm()
    {
        GameObject.FindGameObjectWithTag("GameController").GetComponent<LevelManager>().NextLevel();
        CloseCanvas();
    }
}
