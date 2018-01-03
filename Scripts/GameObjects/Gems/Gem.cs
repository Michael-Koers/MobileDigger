using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{
    public int value;
    [HideInInspector] public string gemName;

    public bool rotateClockwise;
    public float rotationSpeed;

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
        transform.Rotate(new Vector3(0, 0, ((rotateClockwise ? 1 : -1) * rotationSpeed * Time.deltaTime)));
    }

}
