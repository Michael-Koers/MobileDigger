using System.Collections;
using System.Collections.Generic;

public class Inventory : PlayerItem
{
    public int inventorySpace;

    public Inventory(int space, int cost, string name)
    {
        this.inventorySpace = space;
        this.cost = cost;
        this.name = name;
    }
}
