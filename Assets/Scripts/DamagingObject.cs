

using UnityEngine;
using System.Collections;

public class DamagingObject : MonoBehaviour
{
    bool _active;

    public int Damage;
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
    
    void OnTriggerEnter(Collider coll)
    {
        if (coll.GetComponent<IHealth>() == null)
            return;
        coll.gameObject.GetComponent<IHealth>().ModifyHealth(Damage);
        print(coll.gameObject.GetComponent<IHealth>().ReturnHealth());
    }

}
