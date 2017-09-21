using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirtController : MonoBehaviour
{

    public static DirtController selected;
    public float healthPoints = 5;
    public int damage = 1;

    private CanvasGroup hpCanvas;
    [HideInInspector] public float currentHP;

    [SerializeField] private Sprite selectedSprite;
    private Sprite defaultSprite;
    private SpriteRenderer sprender;


    private void Awake()
    {
        sprender = GetComponent<SpriteRenderer>();
        defaultSprite = sprender.sprite;
        currentHP = healthPoints;
        hpCanvas = GameObject.FindGameObjectWithTag("HPCanvas").GetComponent<CanvasGroup>();
    }

    private void OnMouseDown()
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
