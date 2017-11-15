using UnityEngine;

public class EntranceController : LevelController
{
    public void onMouseClick()
    {
        selected = this;
        CanvasManager.ShowCanvas(nextLevelCanvas);
        UnselectDirt();
    }

    public override void confirm()
    {
        Debug.Log("Entrance confirmed");
    }

    public override void cancel()
    {
        Debug.Log("Entrance cancelled");

    }
}