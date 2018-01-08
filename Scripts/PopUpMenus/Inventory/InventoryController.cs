using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : PopUpController
{
    private Animator inventoryAnimation;
    private static string inventoryAnimationBoolean = "inventoryOpen";

    public void Awake()
    {
        inventoryAnimation = GameObject.FindGameObjectWithTag("InventoryCanvas").GetComponent<Animator>(); ;
    }

    public override void openPopUpScreen()
    {
        inventoryAnimation.SetBool(inventoryAnimationBoolean, true);
        openedPopUp = this;
    }

    public override void closePopUpScreen()
    {
        inventoryAnimation.SetBool(inventoryAnimationBoolean, false);
    }
}
