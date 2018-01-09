using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryController : PopUpController
{
    public GameObject inventoryPanel;
    private Animator inventoryAnimation;
    private InventoryPanelController inventoryPanelController;
    private static string inventoryAnimationBoolean = "inventoryOpen";

    public void Awake()
    {
        inventoryAnimation = inventoryPanel.GetComponent<Animator>();
        inventoryPanelController = inventoryPanel.GetComponent<InventoryPanelController>();
    }

    public override void openPopUpScreen()
    {
        inventoryAnimation.SetBool(inventoryAnimationBoolean, true);
        openedPopUp = this;
        inventoryPanelController.updateInventory();
    }

    public override void closePopUpScreen()
    {
        inventoryAnimation.SetBool(inventoryAnimationBoolean, false);
        inventoryPanelController.resetScrollView();
    }


}
