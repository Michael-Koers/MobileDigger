using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
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

    public Animation animation;

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
        if (animation.isSpinning)
        {
            transform.Rotate(new Vector3(0, 0, ((animation.rotateClockwise ? 1 : -1) * animation.rotationSpeed * Time.deltaTime)));
        }
        if (animation.isScaling)
        {
            animation.scaleTimer += Time.deltaTime;

            if (animation.scalingUp)
            {
                transform.localScale = Vector3.Lerp(transform.localScale, animation.endScale, animation.scaleSpeed * Time.deltaTime);
            }
            else if (!animation.scalingUp)
            {
                transform.localScale = Vector3.Lerp(transform.localScale, animation.startScale, animation.scaleSpeed * Time.deltaTime);
            }

            if (animation.scaleTimer >= animation.scaleRate)
            {
                if (animation.scalingUp) { animation.scalingUp = false; }
                else if (!animation.scalingUp) { animation.scalingUp = true; }
                animation.scaleTimer = 0;
            }
        }
    }

}
