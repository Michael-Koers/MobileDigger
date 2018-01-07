using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : PlayerItem
{
    public int maxLevel;
    public int levelPrecision;

    public Elevator(int max, int precision, int cost, string name)
    {
        this.maxLevel = max;
        this.levelPrecision = precision;
        this.cost = cost;
        this.name = name;
    }
}
