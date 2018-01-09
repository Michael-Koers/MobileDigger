using System.Collections;
using System.Collections.Generic;

public class Inventory : PlayerItem
{
    public int inventorySpace;
    public List<Gem> pickedUpItems;

    public Inventory(int space, int cost, string name)
    {
        this.inventorySpace = space;
        this.cost = cost;
        this.name = name;

        pickedUpItems = new List<Gem>(this.inventorySpace);
    }
}
