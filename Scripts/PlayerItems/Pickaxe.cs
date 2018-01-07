using System.Collections;
using System.Collections.Generic;

public class Pickaxe : PlayerItem
{
    public int damage;

    public Pickaxe(int damage, int cost, string name)
    {
        this.damage = damage;
        this.cost = cost;
        this.name = name;
    }

}
