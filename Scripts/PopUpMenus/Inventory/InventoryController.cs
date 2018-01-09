using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryController : PopUpController
{
    private Animator inventoryAnimation;
    private static string inventoryAnimationBoolean = "inventoryOpen";

    public GameObject inventoryItems;
    public GameObject totalValueItems;
    public GameObject spacesLeft;

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
        Text totalValueText = totalValueItems.GetComponent<Text>();
        Text spacesLeftText = spacesLeft.GetComponent<Text>();

        spacesLeftText.text = "Inventory space: " + Player.player.inventory.pickedUpItems.Count + "/" + Player.player.inventory.inventorySpace;

        if (Player.player.inventory.pickedUpItems.Count == 0)
        {
            inventoryText.text = "No gems found yet!";
        }
        else
        {
            string gemList = "";
            int totalValue = 0;

            foreach (Gem pickedUpGem in Player.player.inventory.pickedUpItems)
            {
                gemList += string.Format("-{0} ({1}G) \n", pickedUpGem.gemName, pickedUpGem.value);
                totalValue += pickedUpGem.value;
            }

            inventoryText.text = gemList;
            totalValueText.text = "Total value: " + totalValue;
        }
    }
}
