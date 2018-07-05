using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUpgradesController : UpgradesController
{
    private Dictionary<Gem.GemNames, List<Gem>> temp = new Dictionary<Gem.GemNames, List<Gem>>();

    public override void setStoreItems()
    {
        items.Add(new Inventory(10, 50, "Small backpack"));
        items.Add(new Inventory(20, 100, "Medium backpack"));
        items.Add(new Inventory(30, 200, "Large backpack"));
        items.Add(new Inventory(40, 500, "Mammoth backpack"));
        items.Add(new Inventory(50, 1000, "Titanic backpack"));
    }

    public override void givePlayerItem()
    {
        //Copy loot to temp List
        foreach (KeyValuePair<Gem.GemNames, List<Gem>> entry in Player.player.inventory.pickedUpItems)
        {
            if (entry.Value.Count == 0)
            {
                this.temp.Add(entry.Key, new List<Gem>());
            }
            else
            {
                this.temp.Add(entry.Key, entry.Value);
            }
        }

        //Replace the inventory object with new upgraded one
        Player.player.inventory = (Inventory)items[upgradeCount];

        //Place the items in the new inventory object
        foreach (KeyValuePair<Gem.GemNames, List<Gem>> entry in Player.player.inventory.pickedUpItems)
        {
            Player.player.inventory.pickedUpItems.Add(entry.Key, entry.Value);
        }

        //Clear the temp list
        temp.Clear();

        //Upgrade the inventory UI
        GameObject.FindGameObjectWithTag("InventoryCanvas").GetComponent<InventoryPanelController>().upgradeInventory();
    }
}
