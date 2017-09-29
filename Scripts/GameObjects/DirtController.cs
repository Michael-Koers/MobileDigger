using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirtController : MonoBehaviour
{

    public static DirtController selected;
    public int damage = 1;

    private CanvasGroup hpCanvas;

    [HideInInspector] public float healthPoints, currentHP = LevelManager.level;

    [SerializeField] private Sprite selectedSprite;
    private Sprite defaultSprite;
    private SpriteRenderer sprender;


    private void Awake()
    {
        Debug.Log("HP: " + healthPoints);
        sprender = GetComponent<SpriteRenderer>();
        defaultSprite = sprender.sprite;
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
        selected.currentHP -= selected.damage;
        if (selected.currentHP <= 0)
        {
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
