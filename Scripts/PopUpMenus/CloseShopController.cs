using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseShopController : MonoBehaviour
{
    public void onMouseClick()
    {
        ShopController.openedPopUp.closePopUpScreen();
    }
}
