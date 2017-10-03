using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirtController : MonoBehaviour
{
    //Selected dirt block
    public static DirtController selected;

    //Dig button canvasgroup
    [HideInInspector] public CanvasGroup hpCanvas;

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
        int level = GameObject.FindGameObjectWithTag("GameController").GetComponent<LevelManager>().level;
        currentHP = (level != 0) ? level : 1; //Because first level is level '0' 
        healthPoints = currentHP;

        //Get reference to the Dig button canvas
        hpCanvas = GameObject.FindGameObjectWithTag("HPCanvas").GetComponent<CanvasGroup>();
    }

    public void onMouseClick()
    {
        selected = this;
        sprender.sprite = selectedSprite;
        CanvasManager.ShowCanvas(hpCanvas);
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
            CanvasManager.HideCanvas(selected.hpCanvas);
            Destroy(selected.gameObject);
            selected = null;
        }

    }
}
