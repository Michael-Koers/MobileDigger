using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchCamera : MonoBehaviour
{
    private Vector2?[] oldTouchPositions = {
        null,
        null
    };
    private Vector2 oldTouchVector;
    private float oldTouchDistance;
    private Camera cameraPlayer;

    public float minZoom;
    public float maxZoom;
    public float cameraMargin;

    private Vector3 startPosition;
    private float startZoom;

    private LevelManager level;

    private void Awake()
    {
        cameraPlayer = GetComponent<Camera>();

        startPosition = cameraPlayer.transform.position;
        startZoom = cameraPlayer.orthographicSize;

        level = GameObject.FindGameObjectWithTag("GameController").GetComponent<LevelManager>();
    }

    private void Update()
    {
        if (Input.touchCount == 0)
        {
            oldTouchPositions[0] = null;
            oldTouchPositions[1] = null;
        }
        else if (Input.touchCount == 1)
        {
            if (oldTouchPositions[0] == null || oldTouchPositions[1] != null)
            {
                oldTouchPositions[0] = Input.GetTouch(0).position;
                oldTouchPositions[1] = null;
            }
            else
            {
                if (Input.GetTouch(0).phase == TouchPhase.Moved)
                {
                    Vector2 newTouchPosition = Input.GetTouch(0).position;

                    transform.position += transform.TransformDirection((Vector3)((oldTouchPositions[0] - newTouchPosition) * cameraPlayer.orthographicSize / cameraPlayer.pixelHeight * 2f));

                    oldTouchPositions[0] = newTouchPosition;
                }
            }
        }
        else
        {
            if (oldTouchPositions[1] == null)
            {
                oldTouchPositions[0] = Input.GetTouch(0).position;
                oldTouchPositions[1] = Input.GetTouch(1).position;
                oldTouchVector = (Vector2)(oldTouchPositions[0] - oldTouchPositions[1]);
                oldTouchDistance = oldTouchVector.magnitude;
            }
            else
            {
                Vector2[] newTouchPositions = {
                    Input.GetTouch(0).position,
                    Input.GetTouch(1).position
                };
                Vector2 newTouchVector = newTouchPositions[0] - newTouchPositions[1];
                float newTouchDistance = newTouchVector.magnitude;

                if (level.level == 0)
                {
                    cameraPlayer.orthographicSize = Mathf.Clamp(cameraPlayer.orthographicSize * (oldTouchDistance / newTouchDistance), minZoom / 2, maxZoom / 2);
                }
                else
                {
                    cameraPlayer.orthographicSize = Mathf.Clamp(cameraPlayer.orthographicSize * (oldTouchDistance / newTouchDistance), minZoom, (maxZoom > level.square) ? level.square : maxZoom);
                }


                oldTouchPositions[0] = newTouchPositions[0];
                oldTouchPositions[1] = newTouchPositions[1];
                oldTouchVector = newTouchVector;
                oldTouchDistance = newTouchDistance;
            }
        }
        if (level.level == 0)
        {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, -1, 1), Mathf.Clamp(transform.position.y, -2, 2), transform.position.z);
        }
        else
        {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, cameraMargin, level.square - 1 - cameraMargin), Mathf.Clamp(transform.position.y, cameraMargin, level.square - 1 - cameraMargin), transform.position.z);
        }
    }

    public void ResetCamera()
    {
        cameraPlayer.transform.position = startPosition;
        cameraPlayer.orthographicSize = startZoom;
    }
}
