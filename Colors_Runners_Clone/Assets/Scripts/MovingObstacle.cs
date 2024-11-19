using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObstacle : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float moveDistance = 2f; 

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        float newX = Mathf.PingPong(Time.time * moveSpeed, moveDistance * 2) - moveDistance;

        transform.position = new Vector3(startPosition.x + newX, transform.position.y, transform.position.z);
    }
}
