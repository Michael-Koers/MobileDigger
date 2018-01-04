using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineController : ShopController
{
    public override void onMouseClick()
    {
        Debug.Log("Entered Mine");
        GameObject.FindGameObjectWithTag("GameController").GetComponent<LevelManager>().NextLevel();
    }
}
