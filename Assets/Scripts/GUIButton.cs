using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GUIButton : MonoBehaviour
{

    public void Play()
    {
        SceneManager.LoadScene("main");
    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void IntroMenu()
    {

        SceneManager.LoadScene("IntroMenu");
    }

}
