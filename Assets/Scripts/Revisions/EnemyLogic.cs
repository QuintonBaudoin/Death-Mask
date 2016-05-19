using UnityEngine;
using System.Collections;
using System;

public class EnemyLogic : MonoBehaviour, IDamageable
{
    [SerializeField] private float TurnAwayDistance = 1.0f; //  Distance traveld before turn
    [SerializeField] private float TurnDelay = 1f;          //  Seconds waited before turn
    [SerializeField] private float Speed = 1f;              //  Speed of entity movement

    [SerializeField] private bool LockY;                    // 
    [SerializeField] private bool OnGround;                 // Ground check

    // Member Variables for IDamageable Interface ////////////
    private bool m_Alive = true;                // Alive Bool   // Enity activates death flow when false 
    [SerializeField] private int m_Health;      // Current Health 
    [SerializeField] private int m_MaxHealth;   // Maxium Health amount 



    //// Use this for initialization
    //void Start()
    //{
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //}

    public bool Alive   // IDamagable Interface Property    // Using m_Alive
    {
        get
        {
            return m_Alive;
        }

        set
        {
            m_Alive = value;
        }
    }

    public int Health   // IDamagable Interface Property    // Using m_Health
    {
        get
        {
            return m_Health;
        }

        set
        {
            m_Health = value;
        }
    }

    public int MaxHealth    // IDamagable Interface Property    // Using m_MaxHealth
    {
        get
        {
            return m_MaxHealth;
        }

        set
        {
            m_MaxHealth = value;
        }
    }

    public void OnDeath()   // IDamagable Interface 
    {
        throw new NotImplementedException();
    }

    public void TakeDamage(GameObject other)
    {
        throw new NotImplementedException();
    }

    
}
