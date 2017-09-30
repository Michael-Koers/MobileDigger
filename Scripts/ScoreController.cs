using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{

    private Text score;

    private void Awake()
    {
        score = GetComponent<Text>();
    }

    private void Update()
    {
        score.text = "" + Player.player.score + " Gold";
    }
}
