using UnityEngine;
using System.Collections;

public class PlayButton : MonoBehaviour
{
    public void StartGame()
    {
        Application.LoadLevel("main");
    }
}
