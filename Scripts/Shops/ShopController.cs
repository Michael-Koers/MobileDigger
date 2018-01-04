using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShopController : MonoBehaviour
{
    public Vector2 position;

    public abstract void onMouseClick();
}
