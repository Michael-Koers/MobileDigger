using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YesButtonController : MonoBehaviour
{

    public void GoNextLevel()
    {
        Debug.Log("Continueing to next level!");
        GameObject.FindGameObjectWithTag("GameController").GetComponent<LevelManager>().NextLevel();
        GameObject.FindGameObjectWithTag("Exit").GetComponent<ExitController>().HideNextLevelPanel();
    }
}
