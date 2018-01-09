using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlotController : MonoBehaviour
{
    public GameObject item;
    [HideInInspector] public Gem gem = null;

    public void setItem(Gem gem)
    {
        this.gem = gem;
        updateImage();
    }

    private void updateImage()
    {
        item.GetComponent<Image>().sprite = gem.getGemImage();
        Color color = GetComponent<Image>().color;
        color.a = 255;
        item.GetComponent<Image>().color = color;
    }
}
