using UnityEngine;
using System.Collections;

public class FinishLineTest : MonoBehaviour // placeholder
{
    public GameObject player;
    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            //Debug.Log("Player hit the Finish line");
            //other.gameObject.transform.position = new Vector3(-40, 0.5f, 0); // placeholder

            Application.LoadLevel("IntroMenu");
        }
    }

}
