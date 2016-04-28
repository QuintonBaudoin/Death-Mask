using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public static class GameManager
{

    public static GameObject SpawnLocation;
              
    public static void LoadLevel(string name)
    {
        SceneManager.LoadScene(name);
    }
    public static void ResetLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }    
    public static void PlayerRecall()
    {
       
        GameObject p = GameObject.FindGameObjectWithTag("Player");
        if (SpawnLocation != null && p != null)
            p.transform.position = SpawnLocation.transform.position;
        else
            throw new System.Exception("Problem Recalling" + p + " to " + SpawnLocation);
    }    
    public static void PlayerRecall(Vector3 pos)
    {
        GameObject p = GameObject.FindGameObjectWithTag("Player");

        if (p != null) 
        p.transform.position = pos;

        else
            throw new System.Exception("Problem Recalling" + p + " to " + pos);


    }

}
