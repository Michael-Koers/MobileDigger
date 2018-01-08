using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemInterestUpgradesController : UpgradesController
{
    public override void setStoreItems()
    {
        items.Add(new GemInterest(10, 100, "10% interest"));
        items.Add(new GemInterest(20, 200, "20% interest"));
        items.Add(new GemInterest(30, 300, "30% interest"));
        items.Add(new GemInterest(40, 400, "40% interest"));
        items.Add(new GemInterest(50, 500, "50% interest"));
        items.Add(new GemInterest(60, 600, "60% interest"));
        items.Add(new GemInterest(70, 700, "70% interest"));
        items.Add(new GemInterest(80, 800, "80% interest"));
        items.Add(new GemInterest(90, 900, "90% interest"));
        items.Add(new GemInterest(100, 1000, "100% interest"));
    }

    public override void givePlayerItem()
    {
        Player.player.interest = (GemInterest)items[upgradeCount];
    }
}
