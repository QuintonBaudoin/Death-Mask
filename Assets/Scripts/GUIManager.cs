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
            if (instance == null)
            {
                instance = (GUIManager)FindObjectOfType(typeof(GUIManager));
            }
            return instance;
        }
    }

    void Start()
    {
        var v = FindObjectsOfType(typeof(Slider));
        foreach(Slider s in v)
        {
            if (s.gameObject.name == "HealthSlider")
                HealthBar = s;
        }
    }


    public bool UpdateHealthBar(int val, int max)
    {
        if (val < HealthBar.minValue)
            return false;

        HealthBar.maxValue = max;
        HealthBar.value = val;
        return true;
    }
}
