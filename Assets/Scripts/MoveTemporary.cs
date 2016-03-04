using UnityEngine;
using System.Collections;

public class MoveTemporary : MonoBehaviour
{
    float speed = 0.1f;    

    void Update()
    {
        if (Input.GetKey(KeyCode.A))
            transform.position += new Vector3(1, 0, 0) * speed;
        if (Input.GetKey(KeyCode.D))
            transform.position += new Vector3(-1, 0, 0) * speed;
        if (Input.GetKey(KeyCode.W))
            transform.position += new Vector3(0, 0, -1) * speed;
        if (Input.GetKey(KeyCode.S))
            transform.position += new Vector3(0, 0, 1) * speed;

    }


}
