using UnityEngine;
using System.Collections;

public class MoveTemporary : MonoBehaviour
{
    float speed = 0.1f;
    float jumpHeight = 5;
    Rigidbody body;

    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(1, 0, 0) * speed;
            transform.forward = new Vector3(1, 0, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(-1, 0, 0) * speed;
            transform.forward = new Vector3(-1, 0, 0);
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += new Vector3(0, 0, -1) * speed;
            transform.forward = new Vector3(0, 0, -1);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += new Vector3(0, 0, 1) * speed;
            transform.forward = new Vector3(0, 0, 1);
        }

    }

    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //body.AddForce(0, jumpHeight, 0);
            body.velocity = new Vector3(0, jumpHeight, 0);
        }
    }


}
