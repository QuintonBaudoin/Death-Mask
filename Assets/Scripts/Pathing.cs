using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Pathing : MonoBehaviour
{
    [SerializeField]
    private float speed = 1;
    
    [SerializeField]
    private bool edgeBounce = false;

    void Update()
    {
        Vector3 translate = new Vector3(speed * Time.deltaTime, 0,0);
        
        transform.position += translate;
    }

    void OnTriggerEnter(Collider co)
    {
        if( edgeBounce && co.gameObject.tag == "Edge")
        {   // Invert directional force 
            speed = speed * -1;
            Debug.Log("Hit");
        }
        if(co.gameObject.tag == "DeathFloor")
        {
            // Event on Death
            Destroy(gameObject);
        }
    }
}
