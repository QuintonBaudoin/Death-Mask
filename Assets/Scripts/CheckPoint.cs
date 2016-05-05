using UnityEngine;
using System.Collections;

public class CheckPoint : MonoBehaviour
{

    void OnTriggerEnter(Collider c)
    {
        if (c.tag == "Player")
        { GameManager.SpawnLocation = gameObject; }
    }

}
