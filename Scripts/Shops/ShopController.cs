using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShopController : MonoBehaviour
{
    public Vector2 position;

    public static ShopController openedShop;

    public abstract void closeShop();
    public abstract void openShop();
}
