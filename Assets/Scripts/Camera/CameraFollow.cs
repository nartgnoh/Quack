using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    public Transform northBoundary;
    public Transform eastBoundary;
    public Transform southBoundary;
    public Transform westBoundary;

    private Transform target;

    private float halfHeight;
    private float halfWidth;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectsWithTag("Player")[0].transform;

        halfHeight = Camera.main.orthographicSize;
        halfWidth = halfHeight * Screen.width / Screen.height;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 temp = target.position + offset;
        temp.x = Mathf.Clamp(temp.x, westBoundary.position.x + halfWidth, eastBoundary.position.x - halfWidth);
        temp.y = Mathf.Clamp(temp.y, southBoundary.position.y + halfHeight, northBoundary.position.y - halfHeight);


        transform.position = temp;
    }
}
