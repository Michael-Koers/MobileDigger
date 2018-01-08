using UnityEngine;
using System.Collections;

public abstract class PopUpController : MonoBehaviour
{
    public static PopUpController openedPopUp;

    public abstract void closePopUpScreen();
    public abstract void openPopUpScreen();
}
