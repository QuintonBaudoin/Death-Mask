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
        Quaternion targetf = Quaternion.Euler(0, 270, 0); // Vector3 Direction Right
        Quaternion targetb = Quaternion.Euler(0, 90, 0);  // Vector3 Direction Left


        if ( edgeBounce && co.gameObject.tag == "Edge")
        {   
            speed = speed * -1;
            if(transform.rotation == targetf)
            {
                transform.rotation = targetb;
            }
            else
            {
                transform.rotation = targetf;
            }
            //Debug.Log("Hit");
        }
        if(co.gameObject.tag == "DeathFloor")
        {
            // Event on Death
            Destroy(gameObject);
        }
    }
}
