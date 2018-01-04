using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Gem : MonoBehaviour
{
    public int value;
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

    public virtual void PickUp()
    {
        Player.AddPoints(value);
        Destroy(this.gameObject);
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
