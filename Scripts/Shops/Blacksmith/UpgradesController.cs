using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class UpgradesController : MonoBehaviour
{
    public int upgradeCount = 0;
    public List<PlayerItem> items = new List<PlayerItem>();

    public GameObject itemPrice;
    public GameObject itemName;
    public GameObject buyButton;

    public void BuyPlayerItem()
    {
        if (Player.player.score >= items[upgradeCount].cost)
        {
            givePlayerItem();
            Player.SubtractPoints(items[upgradeCount].cost);
            upgradeCount++;
            UpdateShop();
        }
        /*
         * else
         * show message to player not enough gold
         * or don't even enable the button <- prefer this one
         */
    }

    //Upon awakening, set the store items and update the shop to show correct items and prices
    public void Awake()
    {
        setStoreItems();
        UpdateShop();
    }

    //Abstract function in which the store items should be created and added to the items list object
    public abstract void setStoreItems();

    public void UpdateShop()
    {
        if (upgradeCount >= items.Count)
        {
            itemPrice.SetActive(false);
            buyButton.SetActive(false);
            itemName.GetComponent<Text>().text = "Sold out!";
        }
        else
        {
            itemPrice.GetComponent<Text>().text = items[upgradeCount].cost + " gold";
            itemName.GetComponent<Text>().text = items[upgradeCount].name;
        }
    }

    //Assign the item to the player, needs implicit implementation, can't be made generic like the rest
    public abstract void givePlayerItem();
}
