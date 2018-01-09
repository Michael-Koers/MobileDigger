using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlotController : MonoBehaviour
{
    public GameObject item;

    public void setItem(Sprite image)
    {
        item.GetComponent<Image>().sprite = image;
        Color color = GetComponent<Image>().color;
        color.a = 255;
        item.GetComponent<Image>().color = color;
    }
}
