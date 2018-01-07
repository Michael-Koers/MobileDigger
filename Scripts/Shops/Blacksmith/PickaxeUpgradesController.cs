using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickaxeUpgradesController : MonoBehaviour
{
    private int upgradeCount = 0;
    public static List<Pickaxe> pickaxes = new List<Pickaxe>();

    public GameObject pickaxePrice;
    public GameObject pickaxeName;
    public GameObject pickaxeButton;

    private void Awake()
    {
        pickaxes.Add(new Pickaxe(5, 10, "Bronze pickaxe"));
        pickaxes.Add(new Pickaxe(10, 100, "Iron pickaxe"));
        pickaxes.Add(new Pickaxe(15, 500, "Steel pickaxe"));
        pickaxes.Add(new Pickaxe(20, 1000, "Chromium pickaxe"));
        pickaxes.Add(new Pickaxe(25, 1500, "Tungsten pickaxe"));
        pickaxes.Add(new Pickaxe(30, 2000, "Titanium pickaxe"));
        pickaxes.Add(new Pickaxe(40, 5000, "Diamond pickaxe"));

        UpdateShop();
    }

    public Pickaxe getNextPickaxeUpgrade()
    {
        return pickaxes[upgradeCount];
    }

    public void BuyPickaxe()
    {
        if (Player.player.score >= pickaxes[upgradeCount].cost)
        {
            Player.player.pickaxe = pickaxes[upgradeCount];
            Player.SubtractPoints(pickaxes[upgradeCount].cost);
            upgradeCount++;
            UpdateShop();
        }
        /*
         * else
         * show message to player not enough gold
         * or don't even enable the button <- prefer this one
         */
    }

    public void UpdateShop()
    {
        if (upgradeCount >= pickaxes.Count)
        {
            pickaxePrice.SetActive(false);
            pickaxeButton.SetActive(false);
            pickaxeName.GetComponent<Text>().text = "Sold out!";
        }
        else
        {
            pickaxePrice.GetComponent<Text>().text = pickaxes[upgradeCount].cost + " gold";
            pickaxeName.GetComponent<Text>().text = pickaxes[upgradeCount].name;
        }
    }


}
