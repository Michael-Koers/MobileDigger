using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlacksmithController : ShopController
{
    private Animator blacksmithAnimation;
    private static string blacksmithAnimationBoolean = "blacksmithOpen";

    public void Awake()
    {
        blacksmithAnimation = GameObject.FindGameObjectWithTag("BlacksmithCanvas").GetComponent<Animator>(); ;
    }

    public override void openShop()
    {
        blacksmithAnimation.SetBool(blacksmithAnimationBoolean, true);
        openedShop = this;
    }

    public override void closeShop()
    {
        blacksmithAnimation.SetBool(blacksmithAnimationBoolean, false);
    }

}
