using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DigController : MonoBehaviour
{
    private Image loadingBar;
    private Text hpText;

    private void Awake()
    {
        CanvasGroup canvas = GetComponentInParent<CanvasGroup>();

        CanvasManager.HideCanvas(canvas);

        loadingBar = GameObject.Find("LoadingBar").GetComponent<Image>();

        hpText = GameObject.Find("HPText").GetComponent<Text>();
    }

    public void Update()
    {
        if (DirtController.selected != null)
        {
            loadingBar.fillAmount = DirtController.selected.currentHP / DirtController.selected.healthPoints;
            hpText.text = string.Format("HP: {0}/{1}", DirtController.selected.currentHP, DirtController.selected.healthPoints);
        }
    }
}
