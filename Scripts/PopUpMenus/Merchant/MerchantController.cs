using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MerchantController : ShopController
{
    private Animator merchantAnimation;
    private static string merchantAnimationBoolean = "merchantOpen";

    public void Awake()
    {
        merchantAnimation = GameObject.FindGameObjectWithTag("MerchantCanvas").GetComponent<Animator>();
    }

    public override void openPopUpScreen()
    {
        merchantAnimation.SetBool(merchantAnimationBoolean, true);
        openedPopUp = this;
    }

    public override void closePopUpScreen()
    {
        merchantAnimation.SetBool(merchantAnimationBoolean, false);
    }
}
