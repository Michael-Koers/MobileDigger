using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YesButtonController : MonoBehaviour
{

    public void ChangeLevel()
    {
        Debug.Log("Changing level!");

        LevelController.selected.confirm();
        //GameObject.FindGameObjectWithTag("GameController").GetComponent<LevelManager>().NextLevel();
        //CanvasManager.HideCanvas(GameObject.FindGameObjectWithTag("Exit").GetComponent<ExitController>().nextLevelCanvas);
    }
}
