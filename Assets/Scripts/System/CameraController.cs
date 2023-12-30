using UnityEngine;
using UnityEngine.Tilemaps;

public class CameraController : MonoBehaviour
{
    private Transform target;
    private Vector3Int mapSize;

    private Vector2 xLimit;

    private float height;
    private float width;
    private Camera cam;

    private float xDefault = 0.32f;

    private void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        mapSize = GameObject.FindGameObjectWithTag("Map").GetComponent<Tilemap>().size;
        
        cam = Camera.main;
        height = Mathf.Round(2f * cam.orthographicSize);
        width = height * cam.aspect;

        xLimit = new Vector2(xDefault, mapSize.x - width);
    }

    private void Update()
    {
        if (target == null) return;

        Vector3 targetPosition = target.position;
        Vector3 camPos = transform.position;

        camPos.x = targetPosition.x;
        if (camPos.x < xLimit.x)
        {
            camPos.x = xLimit.x;
        }

        if (camPos.x > xLimit.y)
        {
            camPos.x = xLimit.y;
        }

        if (targetPosition.y > camPos.y + height / 2)
        {
            camPos.y += height - 1;
        }
        else if (targetPosition.y < camPos.y - height / 2)
        {
            camPos.y -= height - 1;
        }

        transform.position = camPos;
    }
}
