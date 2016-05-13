using UnityEngine;
using System.Collections;

public class DeathFloor : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            other.GetComponent<PlayerCharacter>().OnDeath();
            other.GetComponent<PlayerCharacter>().TakeDamage();
        }
    }
}
