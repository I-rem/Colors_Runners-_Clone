using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.position;
    }

    // LateUpdate is called after all Update functions have been called
    void LateUpdate()
    {
        if (player)
        {
            Vector3 targetpos = new Vector3(player.position.x + offset.x, transform.position.y, player.position.z + offset.z);

            transform.position = targetpos;
        }
        else
        {
            Vector3 targetpos = new Vector3(0, transform.position.y, transform.position.z);

            transform.position = targetpos;
        }
    }
}
