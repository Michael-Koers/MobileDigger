using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{


    public int value;

    public void PickUp()
    {
        Player.AddPoints(value);
        Destroy(this.gameObject);
    }
}
