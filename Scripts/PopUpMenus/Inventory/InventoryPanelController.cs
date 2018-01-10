using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryPanelController : MonoBehaviour
{
    public GameObject inventorySlot;
    public GameObject totalValueItems;
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
        for (int i = 0; i < Player.player.inventory.inventorySpace; i++)
        {
            if (slots.ElementAtOrDefault(i) != null)
            {
                continue;
            }

            GameObject slot = Instantiate(inventorySlot, itemContainer.transform);
            slot.transform.SetParent(itemContainer.transform);
            slots.Add(slot);
        }
    }

    public void updateInventory()
    {
        Text totalValueText = totalValueItems.GetComponent<Text>();
        Text spacesLeftText = spacesLeft.GetComponent<Text>();

        int totalValue = 0;

        spacesLeftText.text = "Inventory space: " + Player.player.inventory.pickedUpItems.Count + "/" + Player.player.inventory.inventorySpace;

        for (int i = 0; i < Player.player.inventory.inventorySpace; i++)
        {
            if (Player.player.inventory.pickedUpItems.ElementAtOrDefault(i) != null)
            {
                slots[i].GetComponent<InventorySlotController>().setItem(Player.player.inventory.pickedUpItems[i]);
                totalValue += Player.player.inventory.pickedUpItems[i].value;
            }
            else
            {
                slots[i].GetComponent<InventorySlotController>().removeItem();
            }
        }

        totalValueText.text = "Total value: " + totalValue;

    }

    public void openActionMenu(Gem gem)
    {
        if (gem != null)
        {
            gemToBeRemoved = gem;
            multiActionButton.setMessage("Do what with this " + gem.gemName + "?");
            CanvasManager.ShowCanvas(multiActionCanvas);
        }
    }

    public void onDropOne()
    {
        Player.player.inventory.pickedUpItems.Remove(gemToBeRemoved);
        Destroy(gemToBeRemoved.gameObject);
        CanvasManager.HideCanvas(multiActionCanvas);
        InventorySlotController.selected.removeItem();
        updateInventory();
    }

    public void onDropAll()
    {
        for (int i = Player.player.inventory.pickedUpItems.Count; i > -1; i--)
        {
            if (Player.player.inventory.pickedUpItems.ElementAtOrDefault(i) != null &&
                string.Equals(Player.player.inventory.pickedUpItems[i].gemName, gemToBeRemoved.gemName))
            {
                Player.player.inventory.pickedUpItems.RemoveAt(i);
                Destroy(slots[i].GetComponent<InventorySlotController>().gem.gameObject);
                slots[i].GetComponent<InventorySlotController>().removeItem();
            }
        }
        CanvasManager.HideCanvas(multiActionCanvas);
        updateInventory();
    }

    public void onDropInventory()
    {
        for (int i = Player.player.inventory.pickedUpItems.Count; i > -1; i--)
        {
            if (Player.player.inventory.pickedUpItems.ElementAtOrDefault(i) != null)
            {
                Player.player.inventory.pickedUpItems.RemoveAt(i);
                Destroy(slots[i].GetComponent<InventorySlotController>().gem.gameObject);
                slots[i].GetComponent<InventorySlotController>().removeItem();
            }
        }
        CanvasManager.HideCanvas(multiActionCanvas);
        updateInventory();
    }
}
