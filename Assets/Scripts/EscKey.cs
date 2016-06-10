using UnityEngine;
using System.Collections;

public class EscKey : MonoBehaviour {


	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            GameManager.LoadLevel("IntroMenu");
	}
}
