using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickaxeUpgradesController : UpgradesController
{
    public override void setStoreItems()
    {
        items.Add(new Pickaxe(5, 10, "Bronze pickaxe"));
        items.Add(new Pickaxe(10, 100, "Iron pickaxe"));
        items.Add(new Pickaxe(15, 500, "Steel pickaxe"));
        items.Add(new Pickaxe(20, 1000, "Chromium pickaxe"));
        items.Add(new Pickaxe(25, 1500, "Tungsten pickaxe"));
        items.Add(new Pickaxe(30, 2000, "Titanium pickaxe"));
        items.Add(new Pickaxe(40, 5000, "Diamond pickaxe"));
    }

    public override void givePlayerItem()
    {
        Player.player.pickaxe = (Pickaxe)items[upgradeCount];
    }
}
