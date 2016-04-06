using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GUIManager : MonoBehaviour
{
    private Slider HealthBar;

    private static GUIManager instance;

    public static GUIManager Instance
    {
        get
        {
            if(instance == null)
            { instance = new GUIManager(); }
            return instance;
        }
    }

    GUIManager() { }

    void Awake()
    {
        HealthBar = (GameObject.Find("HealthSlider") as object) as Slider; 
    }


    bool UpdateHealthBar(int min, int max)
    {


        return false;
    }
}
