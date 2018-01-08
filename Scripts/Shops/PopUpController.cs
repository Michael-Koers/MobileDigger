using UnityEngine;
using System.Collections;

public abstract class PopUpController : MonoBehaviour
{
    public static PopUpController openedShop;

    public abstract void closeShop();
    public abstract void openShop();
}
