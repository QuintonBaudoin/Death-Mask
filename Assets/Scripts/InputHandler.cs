using UnityEngine;
using System.Collections;

public class InputHandler : Singleton<MonoBehaviour>
{

    

    public float speed = 5.0f;
    public float jumpSpeed = 5.0f;
    public float jumpHeight = 5.0f;

    int currentNode;


    KeyCode Left = KeyCode.A;
    KeyCode Right = KeyCode.D;
    KeyCode Up = KeyCode.W;
    KeyCode Down = KeyCode.S;

    KeyCode Jump = KeyCode.Space;
    bool jumping = true;

    
    void Update()
    {
        if(Input.GetKey(Right))
        {
          LevelPath.GetNodes();  
        }


    }


}
