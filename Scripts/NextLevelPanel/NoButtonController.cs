using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoButtonController : MonoBehaviour
{

    public void CancelNextLevel()
    {
        ExitController exit = GameObject.FindGameObjectWithTag("Exit").GetComponent<ExitController>();
        exit.HideNextLevelPanel();
    }
}
