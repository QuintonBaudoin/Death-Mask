using UnityEngine;
using System.Collections;

public class DamagingObject : MonoBehaviour
{
    bool _active;

    public bool active
    {
        get
        {
            return _active;
        }
        set
        {
         
            _active = gameObject.GetComponent<Collider>().enabled = value;
            
        }
    }
    
    void OnCollisionEnter(Collision coll)
    {
        GetComponent<IHealth>();
            print(gameObject.name + "Collided with " + coll.gameObject.name);

    }

}
