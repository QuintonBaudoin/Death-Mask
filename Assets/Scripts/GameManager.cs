using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public static class GameManager
{

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
        GameObject s = GameObject.FindGameObjectWithTag("PlayerSpawnLocation");
        GameObject p = GameObject.FindGameObjectWithTag("Player");
        if (s != null && p != null)
        p.GetComponent<Transform>().position = s.GetComponent<Transform>().position;
    }    
}
