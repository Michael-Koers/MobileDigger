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

    public void resetScrollView()
    {
        itemContainer.GetComponentInParent<ScrollRect>().verticalNormalizedPosition = 1;
    }

    public void Start()
    {
        initiateInventory();
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

        for (int i = 0; i < Player.player.inventory.pickedUpItems.Count; i++)
        {
            slots[i].GetComponent<InventorySlotController>().setItem(Player.player.inventory.pickedUpItems[i]);
            totalValue += Player.player.inventory.pickedUpItems[i].value;
        }

        totalValueText.text = "Total value: " + totalValue;

    }
}
