// Just add this script to your camera. It doesn't need any configuration.

using UnityEngine;

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

    private Vector3 startPosition;
    private float startZoom;

    private void Awake()
    {
        cameraPlayer = GetComponent<Camera>();

        startPosition = cameraPlayer.transform.position;
        startZoom = cameraPlayer.orthographicSize;
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
                Vector2 newTouchPosition = Input.GetTouch(0).position;

                transform.position += transform.TransformDirection((Vector3)((oldTouchPositions[0] - newTouchPosition) * cameraPlayer.orthographicSize / cameraPlayer.pixelHeight * 2f));

                oldTouchPositions[0] = newTouchPosition;
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
                Vector2 screen = new Vector2(cameraPlayer.pixelWidth, cameraPlayer.pixelHeight);

                Vector2[] newTouchPositions = {
                    Input.GetTouch(0).position,
                    Input.GetTouch(1).position
                };
                Vector2 newTouchVector = newTouchPositions[0] - newTouchPositions[1];
                float newTouchDistance = newTouchVector.magnitude;

                transform.position += transform.TransformDirection((Vector3)((oldTouchPositions[0] + oldTouchPositions[1] - screen) * cameraPlayer.orthographicSize / screen.y));
                cameraPlayer.orthographicSize = Mathf.Clamp(cameraPlayer.orthographicSize * (oldTouchDistance / newTouchDistance), minZoom, maxZoom);
                transform.position -= transform.TransformDirection((newTouchPositions[0] + newTouchPositions[1] - screen) * cameraPlayer.orthographicSize / screen.y);

                oldTouchPositions[0] = newTouchPositions[0];
                oldTouchPositions[1] = newTouchPositions[1];
                oldTouchVector = newTouchVector;
                oldTouchDistance = newTouchDistance;
            }
        }
    }

    public void ResetCamera()
    {
        cameraPlayer.transform.position = startPosition;
        cameraPlayer.orthographicSize = startZoom;
    }
}
