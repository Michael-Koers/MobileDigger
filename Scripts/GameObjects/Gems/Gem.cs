using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{
    public int value;
    public string gemName;

    public void Awake()
    {
        transform.rotation = Quaternion.Euler(-90, 0, 0);
        transform.position = new Vector3(transform.position.x, transform.position.y, -5);
    }

    public void PickUp()
    {
        Player.AddPoints(value);
        Destroy(this.gameObject);
    }

    public void OnMouseDown()
    {
        PickUp();
    }

    public void OnBecameVisible()
    {
        GetComponent<AnimationScript>().isAnimated = true;
        GetComponent<AnimationScript>().isRotating = true;
    }
}
