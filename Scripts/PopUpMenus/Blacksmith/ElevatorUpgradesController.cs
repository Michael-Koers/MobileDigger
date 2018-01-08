using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorUpgradesController : UpgradesController
{
    public override void setStoreItems()
    {
        items.Add(new Elevator(10, 1, 100, "Gated elevator"));
        items.Add(new Elevator(25, 5, 100, "Hydraulic elevator"));
        items.Add(new Elevator(50, 10, 100, "MRL elevator"));
        items.Add(new Elevator(100, 10, 100, "Geared elevator"));
        items.Add(new Elevator(150, 15, 100, "Gearless elevator"));
    }

    public override void givePlayerItem()
    {
        Player.player.elevator = (Elevator)items[upgradeCount];
    }
}
