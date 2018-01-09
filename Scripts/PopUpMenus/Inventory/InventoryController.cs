using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryController : PopUpController
{
    private Animator inventoryAnimation;
    private static string inventoryAnimationBoolean = "inventoryOpen";

    public GameObject inventoryItems;

    public void Awake()
    {
        inventoryAnimation = GameObject.FindGameObjectWithTag("InventoryCanvas").GetComponent<Animator>();
    }

    public override void openPopUpScreen()
    {
        inventoryAnimation.SetBool(inventoryAnimationBoolean, true);
        openedPopUp = this;
        updateInventory();
    }

    public override void closePopUpScreen()
    {
        inventoryAnimation.SetBool(inventoryAnimationBoolean, false);
    }

    public void updateInventory()
    {
        Text inventoryText = inventoryItems.GetComponent<Text>();

        if (Player.player.inventory.pickedUpItems.Count == 0)
        {
            inventoryText.text = "No gems found yet!";
        }
        else
        {
            string gemList = "";

            foreach (Gem pickedUpGem in Player.player.inventory.pickedUpItems)
            {
                gemList += "-" + pickedUpGem.gemName + "\n";
            }

            inventoryText.text = gemList;
        }
    }
}
