

using UnityEngine;
using System.Collections;

public class DamagingObject : MonoBehaviour
{
    bool _active = false;

    public bool active
    {
        get
        {
            return _active;
        }
        set
        {
            
            _active  = value;
            
        }
    }
    
    void Start()
    {
        GetComponent<Collider>().isTrigger = true;
    }

    void OnTriggerEnter(Collider coll)
    {
        if (GetComponentInParent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("attack"))
            active = true;
        else active = false;
        if (coll.isTrigger || coll.GetComponent<IDamageable>() == null || active != true)
        {
            return;
        }
        coll.GetComponent<IDamageable>().TakeDamage();


    }

}
