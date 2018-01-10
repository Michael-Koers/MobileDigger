using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlotController : MonoBehaviour
{
    public static InventorySlotController selected;
    public GameObject item;
    public GameObject itemPrice;

    private Sprite noneSprite;
    private int slotNumber;

    [HideInInspector] public Gem gem = null;

    public void Awake()
    {
        noneSprite = item.GetComponent<Image>().sprite;
    }

    public void setItem(Gem gem)
    {
        this.gem = gem;
        updateSlot();
    }

    public void removeItem()
    {
        this.gem = null;
        updateSlot();
    }

    public void updateSlot()
    {
        updateImage();
        updatePrice();
    }

    private void updateImage()
    {
        if (this.gem != null)
        {
            item.GetComponent<Image>().sprite = gem.getGemImage();
            Color color = GetComponent<Image>().color;
            color.a = 255;
            item.GetComponent<Image>().color = color;
        }
        else
        {
            item.GetComponent<Image>().sprite = noneSprite;
            Color color = GetComponent<Image>().color;
            color.a = 0;
            item.GetComponent<Image>().color = color;
        }

    }

    private void updatePrice()
    {
        if (this.gem != null)
        {
            CanvasManager.ShowCanvas(itemPrice.GetComponent<CanvasGroup>());
            itemPrice.GetComponentInChildren<Text>().text = "" + this.gem.value;
        }
        else
        {
            CanvasManager.HideCanvas(itemPrice.GetComponent<CanvasGroup>());
            itemPrice.GetComponentInChildren<Text>().text = "";
        }

    }

    public void onMouseClick()
    {
        selected = this;
        GetComponentInParent<InventoryPanelController>().openActionMenu(this.gem);
    }

}
