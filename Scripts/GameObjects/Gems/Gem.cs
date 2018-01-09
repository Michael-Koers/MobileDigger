using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Gem : MonoBehaviour
{
    public int value;
    private MessagePanelController okMessageController;
    [HideInInspector] public string gemName;

    [Serializable]
    public class Animation
    {
        public bool isSpinning = false;
        public bool isScaling = false;

        public bool rotateClockwise;
        public float rotationSpeed;

        public Vector3 startScale;
        public Vector3 endScale;

        [HideInInspector] public bool scalingUp = true;
        public float scaleSpeed;
        public float scaleRate;
        [HideInInspector] public float scaleTimer;
    }

    public Animation anim;

    private void Awake()
    {
        okMessageController = GameObject.FindGameObjectWithTag("MessageCanvas").GetComponent<MessagePanelController>();
    }

    public virtual void PickUp()
    {
        if (Player.player.inventory.pickedUpItems.Count >= Player.player.inventory.inventorySpace)
        {
            okMessageController.SetMessage("Inventory is full. Sell or drop items to make space.");
            okMessageController.ShowMessage();
        }
        else
        {
            Player.player.inventory.pickedUpItems.Add(this);
            this.gameObject.SetActive(false);
        }

    }

    public virtual void onMouseClick()
    {
        PickUp();
    }

    public virtual void Update()
    {
        if (anim.isSpinning)
        {
            transform.Rotate(new Vector3(0, 0, ((anim.rotateClockwise ? 1 : -1) * anim.rotationSpeed * Time.deltaTime)));
        }
        if (anim.isScaling)
        {
            anim.scaleTimer += Time.deltaTime;

            if (anim.scalingUp)
            {
                transform.localScale = Vector3.Lerp(transform.localScale, anim.endScale, anim.scaleSpeed * Time.deltaTime);
            }
            else if (!anim.scalingUp)
            {
                transform.localScale = Vector3.Lerp(transform.localScale, anim.startScale, anim.scaleSpeed * Time.deltaTime);
            }

            if (anim.scaleTimer >= anim.scaleRate)
            {
                if (anim.scalingUp) { anim.scalingUp = false; }
                else if (!anim.scalingUp) { anim.scalingUp = true; }
                anim.scaleTimer = 0;
            }
        }
    }

}
