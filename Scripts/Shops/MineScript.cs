using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineScript : MonoBehaviour
{

    public Vector2 position;

    public void onMouseClick()
    {
        Debug.Log("Entered Mine");
        GameObject.FindGameObjectWithTag("GameController").GetComponent<LevelManager>().NextLevel();
    }
}
