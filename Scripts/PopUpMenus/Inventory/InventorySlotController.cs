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

    [HideInInspector] public List<Gem> gems = null;

    public void Awake()
    {
        noneSprite = item.GetComponent<Image>().sprite;
    }

    public void setItem(List<Gem> gem)
    {
        this.gems = gem;
        updateSlot();
    }

    public void removeItem()
    {
        this.gems = null;
        updateSlot();
    }

    public void updateSlot()
    {
        updateImage();
        updateAmount();
    }

    private void updateImage()
    {
        if (this.gems.Count == 0)
        {
            item.GetComponent<Image>().sprite = gems[0].getGemImage();
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

    private void updateAmount()
    {
        if (this.gems != null)
        {
            CanvasManager.ShowCanvas(itemPrice.GetComponent<CanvasGroup>());
            itemPrice.GetComponentInChildren<Text>().text = "" + this.gems.Count;
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
        GetComponentInParent<InventoryPanelController>().openActionMenu(this.gems);
    }

}
