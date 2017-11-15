using UnityEngine;

abstract public class LevelController : MonoBehaviour
{
    abstract public void cancel();
    abstract public void confirm();

    public static LevelController selected; 

    [HideInInspector] public CanvasGroup nextLevelCanvas;

    private void Start()
    {
        nextLevelCanvas = GameObject.FindGameObjectWithTag("NextLevelCanvas").GetComponent<CanvasGroup>();
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
}