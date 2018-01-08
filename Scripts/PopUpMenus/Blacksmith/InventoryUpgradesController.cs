using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUpgradesController : UpgradesController
{
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
        Player.player.inventory = (Inventory)items[upgradeCount];
    }
}
