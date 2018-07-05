using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Inventory : PlayerItem
{
    public int inventorySpace;
    public Dictionary<Gem.GemNames, List<Gem>> pickedUpItems = new Dictionary<Gem.GemNames, List<Gem>>();

    public Inventory(int space, int cost, string name)
    {
        this.inventorySpace = space;
        this.cost = cost;
        this.name = name;
    }

    public bool isInventoryFull()
    {
        return getInventoryCount() >= inventorySpace;
    }

    public int getFreeInventorySpace()
    {
        return inventorySpace - getInventoryCount();
    }

    public List<Gem> getTypeOfGems(Gem.GemNames gemName)
    {
        return pickedUpItems[gemName];
    }

    public void addItem(Gem gem)
    {
        if (pickedUpItems.ContainsKey(gem.gemName))
        {
            pickedUpItems[gem.gemName].Add(gem);
        }
        else
        {
            pickedUpItems.Add(gem.gemName, new List<Gem> { gem });
        }

    }

    public void removeGem(Gem gem)
    {
        pickedUpItems[gem.gemName].Remove(gem);
    }

    public void removeTypeGem(Gem.GemNames gemType)
    {
        pickedUpItems[gemType].Clear();
    }

    public int getGemTypeTotalValue(Gem.GemNames gemType)
    {
        int gemValue = pickedUpItems[gemType][0].value;

        return pickedUpItems[gemType].Count * gemValue;
    }

    public void clearInventory()
    {
        foreach (KeyValuePair<Gem.GemNames, List<Gem>> entry in pickedUpItems)
        {
            entry.Value.Clear();
        }
    }

    private int getInventoryCount()
    {
        int count = 0;
        foreach (var entry in pickedUpItems)
        {
            count += entry.Value.Count;
        }
        return count;
    }
}
