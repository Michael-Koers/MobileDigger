using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoader : MonoBehaviour
{

    public GameObject gameManager;
    public GameObject player;

    void Awake()
    {
        if (GameManager.instance == null)
        {
            Instantiate(gameManager);
        }

        if (Player.player == null)
        {
            Instantiate(player);
        }
    }
}
