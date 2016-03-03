using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class LevelNode : MonoBehaviour
{

   

    public Vector3 Position
    {
        get
        {
            return gameObject.transform.position;
        }
    }

}
