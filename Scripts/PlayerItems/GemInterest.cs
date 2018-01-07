using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemInterest : PlayerItem
{
    public float gemInterest;

    public GemInterest(float interest, int cost, string name)
    {
        this.gemInterest = interest;
        this.cost = cost;
        this.name = name;
    }
}
