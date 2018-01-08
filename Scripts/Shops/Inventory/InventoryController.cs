using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : ShopController
{
    private Animator inventoryAnimation;
    private static string inventoryAnimationBoolean = "inventoryOpen";

    public void Awake()
    {
        inventoryAnimation = GameObject.FindGameObjectWithTag("InventoryCanvas").GetComponent<Animator>(); ;
    }

    public override void openShop()
    {
        inventoryAnimation.SetBool(inventoryAnimationBoolean, true);
        openedShop = this;
    }

    public override void closeShop()
    {
        inventoryAnimation.SetBool(inventoryAnimationBoolean, false);

    }
}
