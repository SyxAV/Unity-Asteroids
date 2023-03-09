using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector3 moveDir;

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            moveDir = new Vector3(0, 1, 0);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            moveDir = new Vector3(0, -1, 0);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            moveDir = new Vector3(-1, 0, 0);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            moveDir = new Vector3(1, 0, 0);
        }
        else
        {
            moveDir = Vector3.zero;
        }

        float moveSpeed = 3 * Time.deltaTime;
        transform.position += moveSpeed * moveDir;
    }
}
