﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitController : LevelController
{ 
    public void onMouseClick()
    {
        selected = this;
        CanvasManager.ShowCanvas(nextLevelCanvas);
        UnselectDirt();
    }

    public override void confirm()
    {
        Debug.Log("Exit confirmed");
    }

    public override void cancel()
    {
        Debug.Log("Exit cancelled");
    }

}
