using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerTest : MonoBehaviour
{
    [SerializeField]
    private int health;
    [SerializeField]
    private int maxHealth;
    [SerializeField]
    Slider slide;



    void OnAwake()
    {
        slide.wholeNumbers  = true;
        slide.maxValue      = maxHealth;
        slide.minValue      = 0;
        slide.value         = health;
    }


    [ContextMenu("Damage")]
    void TakeDamage()
    {
        health--;
        slide.value = health;
    }
}
