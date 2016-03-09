using UnityEngine;
using System.Collections;
using System;

public class Enemy : MonoBehaviour, IHealth
{
    [SerializeField]
    private int Health;

    public void ModifyHealth(int damage)
    {
        throw new NotImplementedException();
    }

    public int ReturnHealth()
    {
        return Health;
    }
	
	// Update is called once per frame
	void Update () {

    }

    void OnTriggerEnter(Collider co)
    {
        IHealth test = co.gameObject.GetComponent<IHealth>();
        if (co.gameObject.tag == "Player" && test != null )
        {
            test.ModifyHealth(1);
        }
    }
}
