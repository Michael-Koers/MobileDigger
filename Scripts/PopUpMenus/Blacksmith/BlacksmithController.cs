using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlacksmithController : ShopController
{
    private Animator blacksmithAnimation;
    private ScrollRect blacksmithScrollView;
    private static string blacksmithAnimationBoolean = "blacksmithOpen";

    public void Awake()
    {
        blacksmithAnimation = GameObject.FindGameObjectWithTag("BlacksmithCanvas").GetComponent<Animator>();
        blacksmithScrollView = GameObject.FindGameObjectWithTag("BlacksmithCanvas").GetComponentInChildren<ScrollRect>();
    }

    public override void openPopUpScreen()
    {
        blacksmithAnimation.SetBool(blacksmithAnimationBoolean, true);
        openedPopUp = this;
        resetScrollView();
    }

    public override void closePopUpScreen()
    {
        blacksmithAnimation.SetBool(blacksmithAnimationBoolean, false);
    }

    public void resetScrollView()
    {
        blacksmithScrollView.verticalNormalizedPosition = 1;
    }

}
