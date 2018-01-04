using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineController : ShopController
{
    class MineMessage : LevelController
    {
        public override void Confirm()
        {
            GameObject.FindGameObjectWithTag("GameController").GetComponent<LevelManager>().NextLevel();
            CloseCanvas();
        }

        public void showMessage()
        {
            selected = this;
            yesNoController.SetMessage(enterMineMessage);
            CanvasManager.ShowCanvas(yesNoCanvas);
        }
    }

    private MineMessage message;

    public void Awake()
    {
        message = gameObject.AddComponent<MineMessage>();
    }

    public override void onMouseClick()
    {
        message.showMessage();
    }
}
