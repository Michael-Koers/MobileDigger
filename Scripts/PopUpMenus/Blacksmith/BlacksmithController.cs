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

    public override void openPopUpScreen()
    {
        blacksmithAnimation.SetBool(blacksmithAnimationBoolean, true);
        openedPopUp = this;
    }

    public override void closePopUpScreen()
    {
        blacksmithAnimation.SetBool(blacksmithAnimationBoolean, false);
    }

}
