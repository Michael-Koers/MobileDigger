using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MerchantController : ShopController
{
    public override void closePopUpScreen()
    {
        throw new System.NotImplementedException();
    }

    public override void openPopUpScreen()
    {
        Debug.Log("clicked merchant");
    }
}
