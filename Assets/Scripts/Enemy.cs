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
    void Update()
    {
       // print(GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("postdeath"));
        if(GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("postdeath"))
        { 
            Destroy(parent);
            Destroy(gameObject);
        }
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
            parent.GetComponent<Pathing>().enabled = !parent.GetComponent<Pathing>().enabled;
            anim.SetTrigger("Dead");
            Alive = false;
    }

    //[ContextMenu ("Damage")]
    public void TakeDamage(GameObject hitter)
    {
        // trigger animation
        Health --;
        if(Health < 1)
        {
            //Debug.Log(Health);
            OnDeath();
        }
    }

    void OnTriggerStay(Collider c)
    {
        if(c.gameObject.GetComponent<IDamageable>() != null && c.tag == "Player")
        {
            c.GetComponent<IDamageable>().TakeDamage(gameObject);
        }
    }
}
