using UnityEngine;

abstract public class LevelController : MonoBehaviour
{
    abstract public void Confirm();

    public static LevelController selected;

    [HideInInspector] public string nextLevelMessage = "Continue to next level?";
    [HideInInspector] public string prevLevelMessage = "Back to previous level?";

    [HideInInspector] public CanvasGroup yesNoCanvas;
    [HideInInspector] public YesNoPanelController yesNoController;

    private void Start()
    {
        yesNoCanvas = GameObject.FindGameObjectWithTag("YesNoCanvas").GetComponent<CanvasGroup>();
        yesNoController = GameObject.FindGameObjectWithTag("YesNoPanel").GetComponent<YesNoPanelController>();
    }

    public void UnselectDirt()
    {
        //If a dirt block is selected, unselect it and hide dig button
        if (DirtController.selected)
        {
            CanvasManager.HideCanvas(DirtController.selected.hpCanvas);
            DirtController.selected = null;
        }
    }

    public virtual void Cancel()
    {
        CloseCanvas();
    }

    public void CloseCanvas()
    {
        CanvasManager.HideCanvas(yesNoCanvas);
    }
}