using UnityEngine;
using System.Collections.Generic;

public class GetEm : MonoBehaviour {
    public List<GameObject> players = new List<GameObject>();

    // Use this for initialization
    [ContextMenu("Start")]
    public void Start()
    {
        foreach(GameObject go in GameObject.FindGameObjectsWithTag("Player"))
        {
            players.Add(go);
            
        }
        for(int i = 0; i < players.Count; i++)
            if(!players[i].GetComponent<PlayerCharacter>())
            {
                Destroy(players[i]);
            }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
