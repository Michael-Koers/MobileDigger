using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public static Player player;
    public bool isGodMode;

    public Pickaxe pickaxe = new Pickaxe(1, 0, "Wooden pickaxe");

    public float score;

    //Use a different variable in rest of application to allow easy 'God mode' coding
    public int playerDamage
    {
        get
        {
            if (isGodMode)
            {
                return 9999;
            }
            else
            {
                return pickaxe.damage;
            }
        }
    }

    private void Awake()
    {
        if (player == null)
        {
            player = this;
        }
        else if (player != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    public static void AddPoints(int points)
    {
        player.score += points;
    }

    public static void SubtractPoints(int points)
    {
        if (player.score >= points)
        {
            player.score -= points;
        }
    }
}
