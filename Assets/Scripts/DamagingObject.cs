

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
    
    void Start()
    {
        GetComponent<Collider>().isTrigger = true;
    }

    void OnTriggerEnter(Collider coll)
    {
        if (coll.GetComponent<IDamageable>() == null)
            return;
        coll.GetComponent<IDamageable>().TakeDamage();
    }

}
