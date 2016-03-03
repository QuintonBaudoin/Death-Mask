using UnityEngine;
using System.Collections;

public class InputHandler : MonoBehaviour
{
    
    public float speed = 5.0f;
    KeyCode Left = KeyCode.A;
    KeyCode Right = KeyCode.D;
    KeyCode Up = KeyCode.W;
    KeyCode Down = KeyCode.D;

    KeyCode Jump = KeyCode.Space;
    bool canJump = true;

    void Update()
    {
        Vector3 pos = transform.position;

        if (Input.GetKey(Left))
        {
            pos.x-=speed*Time.deltaTime;
        }
        if (Input.GetKey(Right))
        {
            pos.x+=speed * Time.deltaTime;
        }
        if (Input.GetKey(Up))
        {
           //do shit
        }
        if (Input.GetKey(Down))
        {
            //do shit
        }
        if (Input.GetKey(Jump))
        {
            //
        }

        transform.position = pos;
    }

    void OnCollision(Collision c)
    {
       
    }

}
