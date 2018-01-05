using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MerchantController : ShopController
{
    public override void closeShop()
    {
        throw new System.NotImplementedException();
    }

    public override void openShop()
    {
        Debug.Log("clicked merchant");
    }
}
