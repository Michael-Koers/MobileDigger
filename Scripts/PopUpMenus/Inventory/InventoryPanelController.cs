using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryPanelController : MonoBehaviour
{
    public GameObject inventorySlot;
    public GameObject baseValueItems;
    public GameObject spacesLeft;
    public GameObject itemContainer;

    private List<GameObject> slots = new List<GameObject>();

    private MultiActionsController multiActionButton;
    private CanvasGroup multiActionCanvas;

    private Dictionary<string, MultiActionDelegate.ActionButtonDelegate> actions = new Dictionary<string, MultiActionDelegate.ActionButtonDelegate>();
    private Gem gemToBeRemoved;

    public void resetScrollView()
    {
        itemContainer.GetComponentInParent<ScrollRect>().verticalNormalizedPosition = 1;
    }

    public void Start()
    {
        initiateInventory();

        multiActionButton = GameObject.FindGameObjectWithTag("MultiActionCanvas").GetComponent<MultiActionsController>();
        multiActionCanvas = GameObject.FindGameObjectWithTag("MultiActionCanvas").GetComponent<CanvasGroup>();

        MultiActionDelegate.ActionButtonDelegate dropAll = onDropAll;
        MultiActionDelegate.ActionButtonDelegate dropOne = onDropOne;
        MultiActionDelegate.ActionButtonDelegate dropInventory = onDropInventory;

        actions.Add("Drop one", dropOne);
        actions.Add("Drop all", dropAll);
        actions.Add("Drop inventory", dropInventory);

        multiActionButton.createActionButtons(actions);
    }

    public void upgradeInventory()
    {
        initiateInventory();
        updateInventory();
    }

    public void initiateInventory()
    {
        for (int i = 0; i < Player.player.inventory.pickedUpItems.Count; i++)
        {
            GameObject slot = Instantiate(inventorySlot, itemContainer.transform);
            slot.transform.SetParent(itemContainer.transform);
            slots.Add(slot);
        }
    }

    public void updateInventory()
    {
        Text baseValueText = baseValueItems.GetComponent<Text>();
        Text spacesLeftText = spacesLeft.GetComponent<Text>();

        int baseValue = 0;

        spacesLeftText.text = "Inventory space: " + Player.player.inventory.getFreeInventorySpace() + "/" + Player.player.inventory.inventorySpace;

        int index = 0;
        foreach(KeyValuePair<Gem.GemNames, List<Gem>> entry in Player.player.inventory.pickedUpItems)
        {
            slots[index].GetComponent<InventorySlotController>().setItem(entry.Value);
            baseValue += Player.player.inventory.getGemTypeTotalValue(entry.Key);
        }

        baseValueText.text = "Base value: " + baseValue;

    }

    public void openActionMenu(List<Gem> gem)
    {
        if (gem != null)
        {
            gemToBeRemoved = gem[0];
            multiActionButton.setMessage("What to do with your " + gem[0].gemName + "(s)?");
            CanvasManager.ShowCanvas(multiActionCanvas);
        }
    }

    public void onDropOne()
    {
        Player.player.inventory.removeGem(gemToBeRemoved);
        //Player.player.inventory.pickedUpItems[gemToBeRemoved.gemName].Remove(gemToBeRemoved);
        Destroy(gemToBeRemoved.gameObject);
        CanvasManager.HideCanvas(multiActionCanvas);
        InventorySlotController.selected.removeItem();
        updateInventory();
    }

    public void onDropAll()
    {
        Player.player.inventory.removeTypeGem(gemToBeRemoved.gemName);
        CanvasManager.HideCanvas(multiActionCanvas);
        updateInventory();
    }

    public void onDropInventory()
    {
        Player.player.inventory.clearInventory();

        CanvasManager.HideCanvas(multiActionCanvas);
        updateInventory();
    }
}
