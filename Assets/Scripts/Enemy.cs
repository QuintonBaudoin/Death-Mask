using UnityEngine;
using System.Collections;
using System;

public class Enemy : MonoBehaviour, IDamageable
{
    [SerializeField]
    private int health;
    [SerializeField]
    private int maxHealth;
    [SerializeField]
    private bool alive;

    GameObject parent;
    Animator anim;

    void Start()
    {
        parent = transform.parent.gameObject;
        anim = GetComponent<Animator>();
    }

    public bool Alive
    {
        get
        {
            return alive;
        }

        set
        {
            alive = value;
        }
    }

    public int MaxHealth
    {
        get
        {
            return maxHealth;
        }

        set
        {
            maxHealth = value;
        }
    }

    public int Health
    {
        get
        {
            return health;
        }

        set
        {
            health = value;
        }
    }

    public void OnDeath()
    {
        // trigger animation
        // remove collider
        // sink into earth
    }

    [ContextMenu ("Damage")]
    public void TakeDamage()
    {
        // trigger animation
        Health --;
        if(Health < 1)
        {
            Debug.Log(Health);
            transform.parent = null;
            Destroy(parent);
            anim.SetTrigger("Dead");
        }
    }
}
