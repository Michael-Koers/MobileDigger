using UnityEngine;

public class EntranceController : LevelController
{
    public void onMouseClick()
    {
        selected = this;
        yesNoController.SetMessage(prevLevelMessage);
        CanvasManager.ShowCanvas(yesNoCanvas);
        UnselectDirt();
    }

    public override void Confirm()
    {
        GameObject.FindGameObjectWithTag("GameController").GetComponent<LevelManager>().PreviousLevel();
        CloseCanvas();
    }
}