using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirtController : MonoBehaviour
{
    //Selected dirt block
    public static DirtController selected;

    //Dig button canvasgroup
    private CanvasGroup hpCanvas;

    //Total and current HP of dirt
    [HideInInspector] public float healthPoints;
    [HideInInspector] public float currentHP;

    //Selected and default Sprite + sprite renderer
    [SerializeField] private Sprite selectedSprite;
    private Sprite defaultSprite;
    private SpriteRenderer sprender;

    //Rewarded points for destroying dirt block
    public int value;

    private void Awake()
    {
        //Get a sprite reference of this game object
        sprender = GetComponent<SpriteRenderer>();
        defaultSprite = sprender.sprite;

        //Set HP values of the dirt block
        currentHP = LevelManager.level;
        healthPoints = LevelManager.level;

        //Get reference to the Dig button canvas
        hpCanvas = GameObject.FindGameObjectWithTag("HPCanvas").GetComponent<CanvasGroup>();
    }

    public void onMouseClick()
    {
        selected = this;
        sprender.sprite = selectedSprite;
        ShowDigButton();
    }

    private void Update()
    {
        if (sprender.sprite != defaultSprite && selected != this)
        {
            sprender.sprite = defaultSprite;
        }
    }

    public void DamageDirt()
    {
        selected.currentHP -= Player.player.damage;
        if (selected.currentHP <= 0)
        {
            Player.AddPoints(value);
            selected.HideDigButton();
            Destroy(selected.gameObject);
            selected = null;
        }

    }

    public void ShowDigButton()
    {
        hpCanvas.alpha = 1f;
        hpCanvas.blocksRaycasts = true;
    }

    public void HideDigButton()
    {
        hpCanvas.alpha = 0f;
        hpCanvas.blocksRaycasts = false;
    }
}
